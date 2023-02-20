using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Utilities
{
    public class AstHandler
    {
        public AstHandler(string[] args)
        {

        }


        public static string[] Command(int Position, string AstStr)
        {

            if (Position == 8)
            {
                return new string[] {
                    "/?", "-?", "-h", "/h",
                    "--help",
                    "-v", "--version",
                    "account",
                    "secret",
                    "login",
                    "config",
                    "complete"
                };
            }

            if (Position == 14)
            {
                if (AstStr == "moxpass login")
                {
                    return new string[]
                    {
                        "/?", "-?", "-h", "/h",
                        "--help",
                        "reset"
                    };
                }
            }

            if (Position == 15)
            {
                if (AstStr == "moxpass secret")
                {
                    return new string[]
                    {
                        "/?", "-?", "-h", "/h",
                        "--help",
                        "list",
                        "generate",
                        "show",
                        "clip"
                    };
                }

                if (AstStr == "moxpass config")
                {
                    return new string[]
                    {
                        "/?", "-?", "-h", "/h",
                        "--help",
                        "list",
                        "get",
                        "set"
                    };
                }
            }

            if (Position == 16)
            {
                if (AstStr == "moxpass account")
                {
                    return new string[]
                    {
                        "/?", "-?", "-h", "/h",
                        "--help",
                        "list",
                        "add"
                    };
                }
            }


            return new string[]
            {
                "Invalid Option, see help:",
                "moxpass /?", "moxpass -?",
                "moxpass -h", "moxpass /h",
                "moxpass --help",
            };
        }

    }

    public class AstNode
    {
        public readonly string? CurrentAst;
        public string[]? NextAstOptions;
        public AstNode? Next;

        public AstNode(string? currentAst, 
            string[]? nextAstOptions = null,
            AstNode? next = null)
        {
            CurrentAst = currentAst;
            NextAstOptions = nextAstOptions;
            Next = next;
        }

        public static AstNode Create()
        {
            AstNode n = new AstNode(
                "",
                new string[]
                {
                    "/?", "-?", "-h", "/h",
                    "--help",
                    "-v", "--version",
                    "account",
                    "secret",
                    "login",
                    "config",
                    "complete"
                });
            return n;
        }

        public void BuildNext(string OptSelected)
        {
            if (NextAstOptions is null)
            {
                return;
            }

            if (!NextAstOptions.Contains(OptSelected))
            {
                //TODO: Check if return null or throw exception is better
                return;
            }

            if (OptSelected == "complete") 
            {
                AstNode n = new AstNode(
                    "complete");
                Next = n;
            }
        }
    }
}
