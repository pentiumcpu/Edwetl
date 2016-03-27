using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Edwetl
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("关于 {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("版本 {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region 程序集特性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return "版本:1.0.0.0";
                //return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                //return ((AssemblyDescriptionAttribute)attributes[0]).Description;
                string str = @"更新说明
2014-12-01 齐朝普
初次新建,实现从作业设计初始化Oracle数据库
2015-01-01 齐朝普
更新,实现作业调度知识库基本管理,查询、更新、执行
2015-02-01 齐朝普
更新,实现TD数据到Oracle数据库数据加载
2015-03-01 齐朝普
更新,实现模糊查询
2015-07-01 齐朝普
更新,由于硬盘损坏，导致源码丢失，部分功能重构
1、新增需求文档与库结构检查
2、知识库管理，新增改，进行明细修改
3、连接数据库配置文件独立
2015-07-28 齐朝普
更新，交付物增加运维统计
2015-08-01 齐朝普
更新,实现作业调度自动化生成全流程
1、根据config.xls[x]生成作业调度.xlsx
2、根据作业调度.xlsx生成job.xlsx及对应perl程序
2015-08-13 齐朝普
更新,适应虚拟桌面，连接数据库配置文件与文件同级目录
2015-08-27 齐朝普
更新,支持office2007、2010、2013的操作系统上运行
2015-09-01 齐朝普
更新，支持Teradata知识库管理
2015-09-22 齐朝普
更新，批量知识库管理
2015-12-23 齐朝普
更新，交付物-运维统计,表格填充数字1
2015-12-25 齐朝普
更新，交付物增加客户模型
2016-01-12 齐朝普
更新，交付物-客户模型,增加建表SQL
2016-02-02 齐朝普
更新，交付物-客户模型,增加接口需求
建表及卸载脚本生成目录改为result/sql目录下
联系方式:
QQ:    359922926
E-Mail:13315100785@189.cn";
                return str;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return "产品名称:EDWETL";
                //return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return "版权:齐朝普";
                //return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return "公司名称：东华软件股份公司";
                //return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
