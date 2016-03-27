using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edwetl.src.common
{
    class perlstr
    {
        public string context(string v_JOB_NAME, string v_f_deal_name, string v_JOB_CONF, string v_GROUP_NAME)
        {
            string JOB_NAME, f_deal_name, JOB_CONF, ETL_PUB_PATH;
            ETL_PUB_PATH = "/home/dwetl/etla/master/common";
            JOB_NAME = v_JOB_NAME;
            f_deal_name = v_f_deal_name;
            JOB_CONF = v_JOB_CONF;
            string programname = "";
            if (v_JOB_CONF.Contains("BTEQ"))
            {
                programname = "Teradata处理程序BTEQ";
            }
            else
            {
                programname = "Oracle 存储过程";
            }
            f_deal_name = f_deal_name.Replace("cmm_ETL", "f");
            f_deal_name = f_deal_name.Replace(".pl", "");
            f_deal_name = f_deal_name.Replace("templet", "deal");
            StringBuilder sb = new StringBuilder("");
            sb.Append("###############################################################################\n");
            sb.Append("#filename:" + JOB_NAME + "\n");
            sb.Append("#author: " + System.Environment.UserName + " Auto by " + AppDomain.CurrentDomain.FriendlyName + "\n");
            sb.Append("#function: AUTOMATION 调用" + programname + "\n");
            sb.Append("#frequency:   D  (D-day,M-month,Q-quarter,Y-year)\n");
            sb.Append("#modify history:\n");
            sb.Append("#--modifier    date        description\n");
            sb.Append("#--Auto Create   " + DateTime.Now.ToString() + "  初次建立\n");
            sb.Append("###############################################################################\n");
            sb.Append("use strict;\n");
            sb.Append("#--++Perl's package++--\n");
            sb.Append("#--++Public ETL perl++--\n");
            sb.Append("my $ETL_HOME=\"" + ETL_PUB_PATH + "\";\n");
            sb.Append("my $JOB_PARA=\"" + JOB_CONF + "\";\n");
            sb.Append("#   $ETL_HOME = $ENV{\"AUTO_HOME\"};\n");
            sb.Append("my $DIR_COMM = \"$ETL_HOME/" + v_GROUP_NAME + "\" ;\n");
            sb.Append("my $DIR_DATA = \"$ETL_HOME/DATA\" ;\n");
            sb.Append("my $DIR_LOG = \"$ETL_HOME/LOG\" ;\n");
            sb.Append("my $LOGIN_HOST =$ENV{'LOGIN_HOST'};\n");
            sb.Append("my $LOGIN_PWD =$ENV{'LOGIN_PWD'};\n");
            sb.Append("my $LOGIN_UN =$ENV{'LOGIN_UN'};\n");
            sb.Append("my $COMMON_PATH =$ENV{'COMMON_PATH'};\n");
            sb.Append("if ($COMMON_PATH eq \"\" )\n");
            sb.Append("{\n");
            sb.Append("     $DIR_COMM = \"$ETL_HOME/" + v_GROUP_NAME + "\";\n");
            sb.Append("}\n");
            sb.Append("else\n");
            sb.Append("{\n");
            sb.Append("	$DIR_COMM = \"$COMMON_PATH/" + v_GROUP_NAME + "\";\n");
            sb.Append("}\n");
            sb.Append("unshift(@INC, \"$DIR_COMM\");\n");
            sb.Append("require( \"etl_pub.pl\" );\n");
            sb.Append("#--++变量定义++--\n");
            sb.Append("my $ret;\n");
            sb.Append("#--++ETL AUTOMATION CALL++--\n");
            sb.Append("print \"--PID=$$\\n\";\n");
            sb.Append("print \"调用公共脚本etl_pub.pl:$DIR_COMM/etl_pub.pl\\n\";\n");
            sb.Append("sub main\n");
            sb.Append("{\n");
            sb.Append("     #--++检查日期参数++--\n");
            sb.Append("     if ( $#ARGV < 0 ) {\n");
            sb.Append("     print \"处理失败 ... 缺少日期参数\\n\";\n");
            sb.Append("     print \"Usage: perl $0 <数据处理日期>\\n\";\n");
            sb.Append("     exit(1);\n");
            sb.Append("    }\n");
            sb.Append(" my $TX_DATE  =@ARGV[0];\n");
            sb.Append(" my $ETL_DATE = f_conv_ETL_DATE ( $TX_DATE );\n");
            sb.Append(" my $DB_PARA = @ARGV[1];\n");
            sb.Append(" $DB_PARA=\"$LOGIN_HOST,$LOGIN_UN,$LOGIN_PWD,$LOGIN_HOST\";\n");
            sb.Append(" my $DIR_PARA = \"$DIR_COMM,$DIR_DATA,$DIR_LOG\" ;\n");
            sb.Append(" $ret  = " + f_deal_name + " ( $ETL_DATE ,$DB_PARA ,$DIR_PARA,$JOB_PARA );\n");
            sb.Append(" return $ret;\n");
            sb.Append("}\n");
            sb.Append("$ret = main();\n");
            sb.Append("exit($ret);\n");
            return sb.ToString();
        }
    }
}
