using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Util
{
	internal class SQLiteUtil
	{
		/// <summary>
		/// SQLiteUtil Bean
		/// </summary>
		private static readonly SQLiteUtil util = new SQLiteUtil();

		/// <summary>
		/// SQLite Connection Bean
		/// </summary>
		private readonly SQLiteConnection conn = new SQLiteConnection();

		/// <summary>
		/// 数据查询
		/// </summary>
		/// <param name="sql">sql 语句</param>
		/// <returns>结果集</returns>
		public SQLiteDataReader ExcuteReader(string sql)
		{
			return ExcuteReader(sql, null);
		}

		/// <summary>
		/// 数据查询
		/// </summary>
		/// <param name="sql">sql 语句</param>
		/// <param name="parameters">参数 键值对</param>
		/// <returns>结果集</returns>
		public SQLiteDataReader ExcuteReader(string sql, Dictionary<string, object> parameters)
		{
			SQLiteCommand cmd = new SQLiteCommand(sql, conn);
			if (parameters != null)
			{
				foreach (KeyValuePair<string, object> pair in parameters)
				{
					cmd.Parameters.AddWithValue(pair.Key, pair.Value);
				}
			}
			return cmd.ExecuteReader();
		}

		/// <summary>
		/// 数据处理（非查询，增、删、改）
		/// </summary>
		/// <param name="sql">sql 语句</param>
		/// <returns>处理行数</returns>
		public int ExecuteNonQuery(string sql)
		{
			return ExecuteNonQuery(sql, null);
		}

		/// <summary>
		/// 数据处理（非查询，增、删、改）
		/// </summary>
		/// <param name="sql">sql 语句</param>
		/// <param name="parameters">参数 键值对</param>
		/// <returns>处理行数</returns>
		public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
		{
			SQLiteCommand cmd = new SQLiteCommand(sql, conn);
			if (parameters != null)
			{
				foreach (KeyValuePair<string, object> pair in parameters)
				{
					cmd.Parameters.AddWithValue(pair.Key, pair.Value);
				}
			}
			return cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// 数据处理
		/// </summary>
		/// <param name="sql">sql 语句</param>
		/// <returns>结果集第一行第一列内容</returns>
		public object ExecuteScalar(string sql)
		{
			return ExecuteScalar(sql, null);
		}

		/// <summary>
		/// 数据处理
		/// </summary>
		/// <param name="sql">sql 语句</param>
		/// <param name="parameters">参数 键值对</param>
		/// <returns>结果集第一行第一列内容</returns>
		public object ExecuteScalar(string sql, Dictionary<string, object> parameters)
		{
			SQLiteCommand cmd = new SQLiteCommand(sql, conn);
			if (parameters != null)
			{
				foreach (KeyValuePair<string, object> pair in parameters)
				{
					cmd.Parameters.AddWithValue(pair.Key, pair.Value);
				}
			}
			return cmd.ExecuteScalar();
		}

		/// <summary>
		/// 附加数据库
		/// </summary>
		/// <param name="alias">别名</param>
		/// <param name="relativePath">数据库文件相对路径(相对程序根目录)</param>
		/// <returns>当前 SQLiteUtil 实例</returns>
		public SQLiteUtil AttachDatabase(string alias, string relativePath)
		{
			return AttachDatabase(alias, relativePath, true);
		}

		/// <summary>
		/// 附加数据库
		/// </summary>
		/// <param name="alias">别名</param>
		/// <param name="path">数据库文件路径</param>
		/// <param name="relative">路径类型：false-绝对路径，true-相对路径(相对程序根目录)</param>
		/// <returns>当前 SQLiteUtil 实例</returns>
		public SQLiteUtil AttachDatabase(string alias, string path, bool relative)
		{
			if(relative)
			{
				path = Path.Combine(Environment.CurrentDirectory, path);
			}
			string sql = string.Format("ATTACH DATABASE '{0}' AS {1}", path, alias);
			SQLiteCommand cmd = new SQLiteCommand(sql, conn);
			int n = cmd.ExecuteNonQuery();
			return this;
		}

		/// <summary>
		/// 开启一个事务
		/// </summary>
		/// <returns> 开始的事务对象</returns>
		public SQLiteTransaction BeginTransaction()
		{
			return conn.BeginTransaction();
		}

		/// <summary>
		/// 打开数据库连接
		/// </summary>
		/// <returns>当前 SQLiteUtil 实例</returns>
		public SQLiteUtil OpenConnection()
		{
			if(conn.State != ConnectionState.Open)
			{
				conn.Open();
			}
			return this;
		}

		/// <summary>
		/// 关闭 数据库连接
		/// </summary>
		/// <returns>当前 SQLiteUtil 实例</returns>
		public SQLiteUtil CloseConnection()
		{
			if(conn.State != ConnectionState.Closed)
			{
				conn.Close();
			}
			return this;
		}

		/// <summary>
		/// 设置数据库连接字符串
		/// </summary>
		/// <param name="relativePath">数据库文件相对路径（相对程序根目录）</param>
		/// <returns>当前 SQLiteUtil 实例</returns>
		public SQLiteUtil SetDatabasePath(string relativePath)
		{
			return SetDatabasePath(relativePath, true);
		}

		/// <summary>
		/// 设置数据库连接字符串
		/// </summary>
		/// <param name="path">数据库文件路径</param>
		/// <param name="relative">路径类型：false-绝对路径，true-相对路径(相对程序根目录)</param>
		/// <returns>当前 SQLiteUtil 实例</returns>
		public SQLiteUtil SetDatabasePath(string path, bool relative)
		{
			if (relative)
			{
				path = Path.Combine(Environment.CurrentDirectory, path);
			}
			conn.ConnectionString = string.Format("Data Source = {0}", path);
			return this;
		}

		/// <summary>
		/// 根据科目ID附加对应的科目数据库到当前连接
		/// </summary>
		/// <param name="subjectId">科目 ID</param>
		/// <returns>当前 SQLiteUtil 实例</returns>
		public SQLiteUtil Attach(long subjectId)
		{
			return util.AttachDatabase(subjectId.ToString(), Path.Combine(DB.BASE_PATH, subjectId.ToString()), false);
		}

		/// <summary>
		/// 初始化 SQLiteUtil 实例，指定 main 数据库路径
		/// </summary>
		/// <returns>SQLiteUtil 实例</returns>
		public static SQLiteUtil Init()
		{
			return util.SetDatabasePath(Path.Combine(DB.BASE_PATH, DB.MAIN_NAME), false);
		}

		/// <summary>
		/// 获取 SQLiteUtil 实例
		/// </summary>
		/// <returns>SQLiteUtil 实例</returns>
		public static SQLiteUtil get()
		{
			return util;
		}
	}
}
