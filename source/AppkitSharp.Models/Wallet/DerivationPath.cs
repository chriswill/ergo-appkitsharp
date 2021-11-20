using System;

namespace AppkitSharp.Models.Wallet
{
    //example: m/44'/429'/0'/0/0
    public class DerivationPath
    {
        private readonly DerivationType[] derivations = new DerivationType[]
        {
            DerivationType.SOFT, // m
            DerivationType.HARD, // purpose
            DerivationType.HARD, // coin
            DerivationType.HARD, // account
            DerivationType.SOFT, // role
            DerivationType.SOFT  // index
        };

        private const char Master = 'm';
        private const char Separator = '/';

        private readonly string[] segments = new string[6];

        /// <summary>
        /// zero based path depth
        /// </summary>
        public bool IsValid { get; }
        public bool IsPartial { get; }
        public bool IsFull => !IsPartial;
        public bool IsRoot { get; }

        public bool IsPublicBranch { get; private set; }

        public char MasterNode => Master;
        public PurposeType Purpose { get; }
        public CoinType Coin { get; }
        public int AccountIndex { get; }
        public RoleType Role { get; }
        public int Index { get; }

        public DerivationPath(string path)
        {
            var seg = path.Split(Separator);
            var depth = seg.Length - 1;
            IsPartial = seg.Length != segments.Length;
            IsRoot = seg[0] == Master.ToString();
            IsPublicBranch = seg[0] != Master.ToString();

            if (depth < 1 || depth > 5) throw new InvalidOperationException("Invalid path");
            if (IsRoot && depth <= 2) throw new InvalidOperationException("Invalid path");

            var dt = new DerivationType[seg.Length];
            for (int i = 0; i< seg.Length; i++)
            {
                dt[i] = seg[i].EndsWith("'") ? DerivationType.HARD : DerivationType.SOFT;
            }

            if (IsRoot)
            {
                InitAccountPath(seg, dt);

                if (!TryParseSegment(1, out PurposeType purposeType))
                {
                    throw new InvalidOperationException($"{nameof(PurposeType)} '{segments[1]}' not supported.");
                }

                if (!TryParseSegment(2, out CoinType coinType))
                {
                    throw new InvalidOperationException($"{nameof(CoinType)} '{segments[2]}' not supported.");
                }

                if (!TryParseSegment(3, out uint accountIx))
                {
                    throw new InvalidOperationException("Invalid accountIx.");
                }

                Purpose = purposeType;
                Coin = coinType;
                AccountIndex = (int)accountIx;
            }

            if (!IsPartial || !IsRoot && IsPartial)
            {
                InitPaymentPath(seg, dt);

                if (!TryParseSegment(4, out RoleType role))
                {
                    throw new InvalidOperationException($"{nameof(RoleType)} '{segments[4]}' not supported.");
                }

                if (!TryParseSegment(5, out uint index))
                {
                    throw new InvalidOperationException("Invalid index.");
                }

                Role = role;
                Index = (int)index;
            }

            IsValid = true;
        }

        private DerivationPath(params object[] segments) : this(FormatPath(segments))
        {
        }

        public DerivationPath(PurposeType purpose, CoinType coin, int accountIx, RoleType role, int index)
            : this(Master, (int)purpose, (int)coin, accountIx, (int)role, index)
        {
        }

        /// <summary>
        /// Apostrophe in the path indicates that BIP32 hardened derivation is used.
        /// </summary>
        /// <param name="segments"></param>
        /// <returns></returns>
        private static string FormatPath(object[] segments)
        {
            string format = segments.GetType() == typeof(string[]) ? 
                string.Join("/", segments) : 
                string.Format("{0}/{1}'/{2}'/{3}'/{4}/{5}", segments);

            return format
                .Replace("/'/'/'/", "") //empty account
                .Replace("//", "");
        }

        /// <summary>
        /// Checks if the first four elements in seg match the derivations array
        /// </summary>
        /// <param name="seg"></param>
        /// <param name="dt"></param>
        private void InitAccountPath(string[] seg, DerivationType[] dt)
        {
            for (int i = 0; i < 4; i++)
            {
                if (dt[i] != derivations[i])
                {
                    throw new InvalidOperationException("Invalid path.");
                }
            }

            Array.Copy(seg, segments, 4);
        }

        /// <summary>
        /// Checks if the last two elements of seg match the derivations array
        /// </summary>
        /// <param name="seg"></param>
        /// <param name="dt"></param>
        private void InitPaymentPath(string[] seg, DerivationType[] dt)
        {
            var segEnd = seg.Length - 1;
            var j = derivations.Length - 1;

            for (int i = segEnd; i > segEnd - 2; i--)
            {
                if (dt[i] != derivations[j--])
                {
                    throw new InvalidOperationException("Invalid path.");
                }
            }
            Array.Copy(seg, segEnd - 1, segments, 4, 2);
        }

        public override string ToString()
        {
            // TODO filter empty segments
            return FormatPath(segments);     //empty index
        }


        private string ReadSegment(int id, bool trim = true)
        {
            return trim ? segments[id].TrimEnd('\'') : segments[id];
        }

        private bool TryParseSegment<T>(int id, out T value) where T : struct
        {
            if (typeof(T).IsEnum) return Enum.TryParse(ReadSegment(id).TrimEnd('\''), out value);
            value = default;
            return false;
        }

        private bool TryParseSegment(int id, out uint value)
        {
            return uint.TryParse(ReadSegment(id), out value);
        }

        public bool IsEip3()
        {
            bool position1 = TryParseSegment(1, out PurposeType purposeType);

            bool position2 = TryParseSegment(2, out CoinType coinType);

            bool position3 = TryParseSegment(3, out uint accountIx) && accountIx == 0;

            return position1 && position2 && position3;
        }

        public DerivationPath ToPublicBranch()
        {
            DerivationPath path = (DerivationPath) MemberwiseClone();
            path.segments[0] = "M";
            IsPublicBranch = true;
            return path;
        }

        public DerivationPath ToPrivateBranch()
        {
            DerivationPath path = (DerivationPath) MemberwiseClone();
            path.segments[0] = "m";
            IsPublicBranch = false;
            return path;
        }

        public static DerivationPath FromPath(string path)
        {
            return new DerivationPath(path);
        }

        public static DerivationPath MasterPath => new DerivationPath(PurposeType.Default, CoinType.Ergo, 0, RoleType.ExternalChain, 0);
    }
}
