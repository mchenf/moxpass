using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Version
{
    // Handles requests for version
    public class VersionHandler
    {
        int major;
        int minor;
        int build;
        int build_version;
        public VersionHandler(int major, int minor, int build, int build_version)
        {
            this.major = major;
            this.minor = minor;
            this.build = build;
            this.build_version = build_version;
        }
        public string GetVersionString()
        {
            var sb = new StringBuilder();
            sb.Append("moxpass")
            .Append(' ')
            .Append(major)
            .Append('.')
            .Append(minor)
            .Append('.')
            .Append(build)
            .Append('.')
            .Append(build_version)
            .Append(' ')
            .Append("Store, manage, and reuse your secrets.");
            return sb.ToString();
        }
    }
}
