using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static System.Console;

namespace JSoku
{
    class JikoInfo
    {
        #region " [ 基本情報 ] "
        public string SID;
        public string NNO;
        public string 事故NO;
        public string 営業所CD;
        public string 営業所;
        public string 事故区分;
        public string 発生日;
        public string 発生時間;
        public string 登録番号;

        public string 車両種別;

        public string 発生場所;
        public string 荷主;
        public string 便名;
        public string 社員CD;
        public string 乗務員名;
        public string 帰庫予定日;
        public string 帰庫予定時刻;

        public string 勤続年数;

        public string 乗務員詳細;
        public string 相手方氏名;
        public string 相手方tel;
        public string 相手方住所;
        public string 相手方詳細;
        public string 物損詳細;
        public string 保険会社CD;
        public string 保険会社名;
        public string 保険会社日付;
        public string 保険会社時刻;
        public string 責任区CD;
        public string 責任区;
        public string 責任区担当;
        public string 所轄署;
        public string 所轄担当;
        public string 状況;
        public string 処置;
        public string 作成者;
        public string 確認者;
        public string 状態;

        public string 更新者ID;
        public string 最終更新日時;
        public string 確認者ID;
        public string 確認日時;
        public string 安全担当ID;
        public string 安全確認日時;
        public string 削除者ID;
        public string 削除日時;
        public string 削除FLG;
        public string 強制FLG;
        public string 非表示FLG;

        public string 版数;
        public string 事故区分_環境;
        public string 事故区分_車両;
        public string 事故区分_荷物;
        public string 事故区分_品質;
        public string 事故区分_労災;
        public string 事故区分_貰い;
        public string 事故累計回数;
        public string 安全品質承認FLG;
        public string 完了;

        public string item1;
        public string item2;
        public string item3;

        public string 部門CD;
        public string 部門名;
        public string 権限CD;

        public void Save()
        {
            MySqlCommand comm = DB.GetCommand();
            MySqlTransaction trans = comm.Connection.BeginTransaction();
            try
            {
                /*----------------------------------------------*/
                /*新規時、主キーセット*/
                /*----------------------------------------------*/
                if (this.SID == DB.NEW_SID)
                {
                    this.SID = DB.GetScalar(" select max(sid)+1 as newSID from t_事故情報 ");
                    this.NNO = DB.GetScalar(" select MAX(CONVERT(事故NO,UNSIGNED))+1 as newNo from t_事故情報 ");
                }

                var query = new System.Text.StringBuilder();
                query.Append(" REPLACE INTO `t_事故情報` (");
                query.Append(" `sid`, ");
                query.Append(" `事故NO`, ");
                query.Append(" `営業所CD`, ");
                query.Append(" `営業所`, ");
                query.Append(" `事故区分`, ");
                query.Append(" `発生日`, ");
                query.Append(" `発生時間`, ");
                query.Append(" `登録番号`, ");
                query.Append(" `発生場所`, ");
                query.Append(" `荷主`, ");
                query.Append(" `便名`, ");
                query.Append(" `社員CD`, ");
                query.Append(" `乗務員名`, ");
                query.Append(" `帰庫予定日`, ");
                query.Append(" `帰庫予定時刻`, ");
                query.Append(" `乗務員詳細`, ");
                query.Append(" `相手方氏名`, ");
                query.Append(" `相手方tel`, ");
                query.Append(" `相手方住所`, ");
                query.Append(" `相手方詳細`, ");
                query.Append(" `物損詳細`, ");
                query.Append(" `保険会社CD`, ");
                query.Append(" `保険会社名`, ");
                query.Append(" `保険会社日付`, ");
                query.Append(" `保険会社時刻`, ");
                query.Append(" `責任区CD`, ");
                query.Append(" `責任区`, ");
                query.Append(" `所轄署`, ");
                query.Append(" `状況`, ");
                query.Append(" `処置`, ");
                query.Append(" `作成者`, ");
                query.Append(" `確認者`, ");
                query.Append(" `状態`, ");
                query.Append(" `更新者ID`, ");
                query.Append(" `最終更新日時`, ");
                query.Append(" `確認者ID`, ");
                query.Append(" `確認日時`, ");
                query.Append(" `安全担当ID`, ");
                query.Append(" `安全確認日時`, ");
                query.Append(" `削除者ID`, ");
                query.Append(" `削除日時`, ");
                query.Append(" `削除FLG`, ");
                query.Append(" `強制FLG`, ");
                query.Append(" `非表示FLG`, ");
                query.Append(" `版数`, ");
                query.Append(" `事故区分_環境`, ");
                query.Append(" `事故区分_車両`, ");
                query.Append(" `事故区分_荷物`, ");
                query.Append(" `事故区分_品質`, ");
                query.Append(" `事故区分_労災`, ");
                query.Append(" `事故区分_貰い`, ");
                query.Append(" `事故累計回数`, ");
                query.Append(" `安全品質承認FLG`, ");
                query.Append(" `責任区担当`, ");
                query.Append(" `所轄担当` ");
                query.Append(" ) ");

                query.Append(" VALUES ( ");
                query.Append(" @sid, ");
                query.Append(" @事故NO, ");
                query.Append(" @営業所CD, ");
                query.Append(" @営業所, ");
                query.Append(" @事故区分, ");
                query.Append(" @発生日, ");
                query.Append(" @発生時間, ");
                query.Append(" @登録番号, ");
                query.Append(" @発生場所, ");
                query.Append(" @荷主, ");
                query.Append(" @便名, ");
                query.Append(" @社員CD, ");
                query.Append(" @乗務員名, ");
                query.Append(" @帰庫予定日, ");
                query.Append(" @帰庫予定時刻, ");
                query.Append(" @乗務員詳細, ");
                query.Append(" @相手方氏名, ");
                query.Append(" @相手方tel, ");
                query.Append(" @相手方住所, ");
                query.Append(" @相手方詳細, ");
                query.Append(" @物損詳細, ");
                query.Append(" @保険会社CD, ");
                query.Append(" @保険会社名, ");
                query.Append(" @保険会社日付, ");
                query.Append(" @保険会社時刻, ");
                query.Append(" @責任区CD, ");
                query.Append(" @責任区, ");
                query.Append(" @所轄署, ");
                query.Append(" @状況, ");
                query.Append(" @処置, ");
                query.Append(" @作成者, ");
                query.Append(" @確認者, ");
                query.Append(" @状態, ");
                query.Append(" @更新者ID, ");
                query.Append(" @最終更新日時, ");
                query.Append(" @確認者ID, ");
                query.Append(" @確認日時, ");
                query.Append(" @安全担当ID, ");
                query.Append(" @安全確認日時, ");
                query.Append(" @削除者ID, ");
                query.Append(" @削除日時, ");
                query.Append(" @削除FLG, ");
                query.Append(" @強制FLG, ");
                query.Append(" @非表示FLG, ");
                query.Append(" @版数, ");
                query.Append(" @事故区分_環境, ");
                query.Append(" @事故区分_車両, ");
                query.Append(" @事故区分_荷物, ");
                query.Append(" @事故区分_品質, ");
                query.Append(" @事故区分_労災, ");
                query.Append(" @事故区分_貰い, ");
                query.Append(" @事故累計回数, ");
                query.Append(" @安全品質承認FLG, ");
                query.Append(" @責任区担当, ");
                query.Append(" @所轄担当 ");
                query.Append(" ) ");

                comm.CommandText = query.ToString();

                comm.Parameters.Add("@sid", MySqlDbType.Int32);
                comm.Parameters["@sid"].Value = this.SID;

                comm.Parameters.Add("@事故NO", MySqlDbType.VarChar);
                comm.Parameters["@事故NO"].Value = this.NNO;

                comm.Parameters.Add("@営業所CD", MySqlDbType.VarChar);
                comm.Parameters["@営業所CD"].Value = this.営業所CD;

                comm.Parameters.Add("@営業所", MySqlDbType.VarChar);
                comm.Parameters["@営業所"].Value = this.営業所;

                comm.Parameters.Add("@事故区分", MySqlDbType.VarChar);
                comm.Parameters["@事故区分"].Value = this.事故区分;

                comm.Parameters.Add("@発生日", MySqlDbType.VarChar);
                comm.Parameters["@発生日"].Value = this.発生日;

                comm.Parameters.Add("@発生時間", MySqlDbType.VarChar);
                comm.Parameters["@発生時間"].Value = this.発生時間;

                comm.Parameters.Add("@登録番号", MySqlDbType.VarChar);
                comm.Parameters["@登録番号"].Value = this.登録番号;

                comm.Parameters.Add("@発生場所", MySqlDbType.VarChar);
                comm.Parameters["@発生場所"].Value = this.発生場所;

                comm.Parameters.Add("@荷主", MySqlDbType.VarChar);
                comm.Parameters["@荷主"].Value = this.荷主;

                comm.Parameters.Add("@便名", MySqlDbType.VarChar);
                comm.Parameters["@便名"].Value = this.便名;

                comm.Parameters.Add("@社員CD", MySqlDbType.VarChar);
                comm.Parameters["@社員CD"].Value = this.社員CD;

                comm.Parameters.Add("@乗務員名", MySqlDbType.VarChar);
                comm.Parameters["@乗務員名"].Value = this.乗務員名;

                comm.Parameters.Add("@帰庫予定日", MySqlDbType.VarChar);
                comm.Parameters["@帰庫予定日"].Value = this.帰庫予定日;

                comm.Parameters.Add("@帰庫予定時刻", MySqlDbType.VarChar);
                comm.Parameters["@帰庫予定時刻"].Value = this.帰庫予定時刻;

                comm.Parameters.Add("@乗務員詳細", MySqlDbType.VarChar);
                comm.Parameters["@乗務員詳細"].Value = this.乗務員詳細;

                comm.Parameters.Add("@相手方氏名", MySqlDbType.VarChar);
                comm.Parameters["@相手方氏名"].Value = this.相手方氏名;

                comm.Parameters.Add("@相手方tel", MySqlDbType.VarChar);
                comm.Parameters["@相手方tel"].Value = this.相手方tel;

                comm.Parameters.Add("@相手方住所", MySqlDbType.VarChar);
                comm.Parameters["@相手方住所"].Value = this.相手方住所;

                comm.Parameters.Add("@相手方詳細", MySqlDbType.VarChar);
                comm.Parameters["@相手方詳細"].Value = this.相手方詳細;

                comm.Parameters.Add("@物損詳細", MySqlDbType.VarChar);
                comm.Parameters["@物損詳細"].Value = this.物損詳細;

                comm.Parameters.Add("@保険会社CD", MySqlDbType.VarChar);
                comm.Parameters["@保険会社CD"].Value = this.保険会社CD;

                comm.Parameters.Add("@保険会社名", MySqlDbType.VarChar);
                comm.Parameters["@保険会社名"].Value = this.保険会社名;

                comm.Parameters.Add("@保険会社日付", MySqlDbType.VarChar);
                comm.Parameters["@保険会社日付"].Value = this.保険会社日付;

                comm.Parameters.Add("@保険会社時刻", MySqlDbType.VarChar);
                comm.Parameters["@保険会社時刻"].Value = this.保険会社時刻;

                comm.Parameters.Add("@責任区CD", MySqlDbType.VarChar);
                comm.Parameters["@責任区CD"].Value = this.責任区CD;

                comm.Parameters.Add("@責任区", MySqlDbType.VarChar);
                comm.Parameters["@責任区"].Value = this.責任区;

                comm.Parameters.Add("@所轄署", MySqlDbType.VarChar);
                comm.Parameters["@所轄署"].Value = this.所轄署;

                comm.Parameters.Add("@状況", MySqlDbType.VarChar);
                comm.Parameters["@状況"].Value = this.状況;

                comm.Parameters.Add("@処置", MySqlDbType.VarChar);
                comm.Parameters["@処置"].Value = this.処置;

                comm.Parameters.Add("@作成者", MySqlDbType.VarChar);
                comm.Parameters["@作成者"].Value = this.作成者;

                comm.Parameters.Add("@確認者", MySqlDbType.VarChar);
                comm.Parameters["@確認者"].Value = this.確認者;

                comm.Parameters.Add("@状態", MySqlDbType.VarChar);
                comm.Parameters["@状態"].Value = this.状態;

                comm.Parameters.Add("@更新者ID", MySqlDbType.VarChar);
                comm.Parameters["@更新者ID"].Value = this.更新者ID;

                comm.Parameters.Add("@最終更新日時", MySqlDbType.VarChar);
                comm.Parameters["@最終更新日時"].Value = this.最終更新日時;

                comm.Parameters.Add("@確認者ID", MySqlDbType.VarChar);
                comm.Parameters["@確認者ID"].Value = this.確認者ID;

                comm.Parameters.Add("@確認日時", MySqlDbType.VarChar);
                comm.Parameters["@確認日時"].Value = this.確認日時;

                comm.Parameters.Add("@安全担当ID", MySqlDbType.VarChar);
                comm.Parameters["@安全担当ID"].Value = this.安全担当ID;

                comm.Parameters.Add("@安全確認日時", MySqlDbType.VarChar);
                comm.Parameters["@安全確認日時"].Value = this.安全確認日時;

                comm.Parameters.Add("@削除者ID", MySqlDbType.VarChar);
                comm.Parameters["@削除者ID"].Value = this.削除者ID;

                comm.Parameters.Add("@削除日時", MySqlDbType.VarChar);
                comm.Parameters["@削除日時"].Value = this.削除日時;

                comm.Parameters.Add("@削除FLG", MySqlDbType.VarChar);
                comm.Parameters["@削除FLG"].Value = this.削除FLG;

                comm.Parameters.Add("@強制FLG", MySqlDbType.VarChar);
                comm.Parameters["@強制FLG"].Value = this.強制FLG;

                comm.Parameters.Add("@非表示FLG", MySqlDbType.VarChar);
                comm.Parameters["@非表示FLG"].Value = this.非表示FLG;

                comm.Parameters.Add("@版数", MySqlDbType.VarChar);
                comm.Parameters["@版数"].Value = this.版数;

                comm.Parameters.Add("@事故区分_環境", MySqlDbType.VarChar);
                comm.Parameters["@事故区分_環境"].Value = this.事故区分_環境;

                comm.Parameters.Add("@事故区分_車両", MySqlDbType.VarChar);
                comm.Parameters["@事故区分_車両"].Value = this.事故区分_車両;

                comm.Parameters.Add("@事故区分_荷物", MySqlDbType.VarChar);
                comm.Parameters["@事故区分_荷物"].Value = this.事故区分_荷物;

                comm.Parameters.Add("@事故区分_品質", MySqlDbType.VarChar);
                comm.Parameters["@事故区分_品質"].Value = this.事故区分_品質;

                comm.Parameters.Add("@事故区分_労災", MySqlDbType.VarChar);
                comm.Parameters["@事故区分_労災"].Value = this.事故区分_労災;

                comm.Parameters.Add("@事故区分_貰い", MySqlDbType.VarChar);
                comm.Parameters["@事故区分_貰い"].Value = this.事故区分_貰い;

                comm.Parameters.Add("@事故累計回数", MySqlDbType.VarChar);
                comm.Parameters["@事故累計回数"].Value = "0";

                comm.Parameters.Add("@安全品質承認FLG", MySqlDbType.VarChar);
                comm.Parameters["@安全品質承認FLG"].Value = this.安全品質承認FLG;

                comm.Parameters.Add("@責任区担当", MySqlDbType.VarChar);
                comm.Parameters["@責任区担当"].Value = this.責任区担当;

                comm.Parameters.Add("@所轄担当", MySqlDbType.VarChar);
                comm.Parameters["@所轄担当"].Value = this.所轄担当;

                _ = comm.ExecuteNonQuery();
                trans.Commit();
            }
            catch(Exception ex)
            {
                trans.Rollback();
                Console.WriteLine(ex.ToString());

            }
            finally
            {

                trans.Dispose();
                comm.Connection.Close();
                comm.Connection.Dispose();
                comm.Dispose();
            }
        }

        public static void ExUnlock()
        {
            var query = new System.Text.StringBuilder();
            query.Append(" delete from t_排他ロック ");
            query.Append(" where `userid`=@userid ");

            MySqlCommand mycomm  = DB.GetCommand();
            mycomm.CommandText = query.ToString();

            mycomm.Parameters.Clear();
            mycomm.Parameters.Add("@userid", MySqlDbType.VarChar);
            mycomm.Parameters["@userid"].Value = DB.Escape(Environment.MachineName);
            //mycomm.Parameters["@userid"].Value = UserInfo.Current.UserId;

            mycomm.ExecuteNonQuery();

        }

        public static Boolean ExCheck(string SID)
        {
            Boolean booRet = false;
            var query = new System.Text.StringBuilder();
            query.Append(" select * from t_排他ロック ");
            query.Append(" where `sid`=" + DB.Escape(SID));
            query.Append("   and `userid`!=" + DB.Escape(Environment.MachineName));  // 自分自身は対象外(解除するので通常ありえない)

            DataTable dt = DB.GetDataTable(query.ToString());

            if(dt.Rows.Count != 0){
                var summary = new System.Text.StringBuilder();
                summary.AppendFormat("他ユーザが編集中のため、読み取り専用で開きます。");
                summary.AppendLine();
                summary.AppendLine();
                summary.AppendFormat("更新中のユーザ：{0}({1})", dt.Rows[0]["userid"].ToString(), dt.Rows[0]["simei"].ToString());
                summary.AppendLine();
                summary.AppendFormat("端末id：{0}", dt.Rows[0]["端末id"].ToString());
                summary.AppendLine();
                summary.AppendFormat("ロック日時：{0}", dt.Rows[0]["ロック日時"].ToString());

                Msg.Info(summary.ToString());
            }

            return booRet;
        }

        public static void ExLock(string SID)
        {
            var query = new System.Text.StringBuilder();
            query.Append(" replace into t_排他ロック( ");
            query.Append("  `sid`, `userid`, `端末id`, `ロック日時` ");
            query.Append(" ) values ( ");
            query.Append("  @sid,  @userid,  @端末id,  sysdate() ");
            query.Append(" ) ");

            MySqlCommand mycomm = DB.GetCommand();
            mycomm.CommandText = query.ToString();

            mycomm.Parameters.Clear();
            mycomm.Parameters.Add("@sid", MySqlDbType.Int32);
            mycomm.Parameters.Add("@userid", MySqlDbType.VarChar);
            mycomm.Parameters.Add("@端末id", MySqlDbType.VarChar);

            mycomm.Parameters["@sid"].Value = SID;
            //mycomm.Parameters["@userid"].Value = UserInfo.Current.UserId;
            mycomm.Parameters["@userid"].Value = Environment.MachineName;
            //mycomm.Parameters["@端末id"].Value = Environment.MachineName;

            mycomm.ExecuteNonQuery();

            mycomm.Dispose();
        }

        #endregion

        public async void sendmail(string userName, string password,string fromUser,string div)
        {
            MySqlConnection myconn = DB.GetConnection();
            var message = new MimeKit.MimeMessage();

            var textPart = new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain);
            var title = "";
            var EMAIL_U = "";
            StringBuilder msgBody = new StringBuilder();
            // 本文を作る
            msgBody.AppendLine("【発生日時】");
            msgBody.AppendFormat("{0} {1}{2}", "　"+this.発生日, this.発生時間, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【発生場所】");
            msgBody.AppendFormat("{0}{1}", "　" + this.発生場所, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【登録番号】");
            msgBody.AppendFormat("{0}{1}", "　" + this.登録番号, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【車両種別】");
            msgBody.AppendFormat("{0}{1}", "　" + this.車両種別, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【荷　　主】");
            msgBody.AppendFormat("{0}{1}", "　" + this.荷主, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【便　　名】");
            msgBody.AppendFormat("{0}{1}", "　" + this.便名, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【乗務員名　勤続年数】");
            msgBody.AppendFormat("{0} {1}{2}", "　" + this.乗務員名, this.勤続年数, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【帰庫予定日　時刻】");
            msgBody.AppendFormat("{0} {1}　{2}", "　" + this.帰庫予定日, this.帰庫予定時刻, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【乗務員詳細】");
            msgBody.AppendFormat("{0}{1}", "　" + this.乗務員詳細, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【相手氏名】");
            msgBody.AppendFormat("{0}{1}", "　" + this.相手方氏名, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【相手TEL】");
            msgBody.AppendFormat("{0}{1}", "　" + this.相手方tel, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【相手住所】");
            msgBody.AppendFormat("{0}{1}", "　" + this.相手方住所, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【相手詳細】");
            msgBody.AppendFormat("{0}{1}", "　" + this.相手方詳細, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【物損詳細】");
            msgBody.AppendFormat("{0}{1}", "　" + this.物損詳細, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【保険会社】");
            msgBody.AppendFormat("{0}{1}", "　" + this.保険会社名, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【保険連絡時刻】");
            msgBody.AppendFormat("{0} {1}{2}", "　" + this.保険会社日付, this.保険会社時刻, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【責任区】");
            msgBody.AppendFormat("{0}{1}", "　" + this.責任区, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【所轄署】");
            msgBody.AppendFormat("{0}{1}", "　" + this.所轄署, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【状　　況】");
            msgBody.AppendFormat("{0}{1}", "　" + this.状況, Environment.NewLine);
            msgBody.AppendLine("");
            msgBody.AppendLine("【処　　置】");
            msgBody.AppendFormat("{0}{1}", "　" + this.処置, Environment.NewLine);

            textPart.Text = msgBody.ToString();

#if DEBUG
            EMAIL_U = "s.ushinohama@ingroup.co.jp";
            message.To.Add(new MimeKit.MailboxAddress("s.ushinohama@ingroup.co.jp"));
            title = "テスト送信";
#else
            //差出人作成
            //String query = String.Format("SELECT t1.`EMAIL` FROM `m管理user`t1 WHERE `t1`.`PC_NAME` = '{0}'", fromUser);
            String query = String.Format("SELECT t1.`Email` FROM `m_管理ユーザー`t1 WHERE `t1`.`Email` = '{0}'", fromUser);
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            while (rs.Read())
            {
                EMAIL_U = DB.NVL(rs["Email"]).ToString();
            }
            rs.Close();

            //同一営業所内への送信先作成
            if (div== "承認待ち")
            {
                title = String.Format("事故速報 第 {0}版 作成完了のお知らせ", Int32.Parse(this.版数) + 1);
                query = String.Format("SELECT t2.`メールアドレス` FROM `m_部門`t2 WHERE t2.`部門コード` = '{0}'", this.営業所CD);
                MySqlDataReader rs1;
                rs1 = DB.GetReader(myconn, query);

                while (rs1.Read())
                {
                    message.To.Add(new MimeKit.MailboxAddress(DB.NVL(rs1["メールアドレス"]).ToString() + "@ingroup.co.jp"));
                }
                rs1.Close();
            }

            //全社員と保険会社の送信先作成
            if (div == "配信済み")
            {
                title = String.Format("事故速報 第 {0}版 {1}", this.版数, this.営業所);
                message.To.Add(new MimeKit.MailboxAddress("all.inl@ingroup.co.jp"));

                query = String.Format("SELECT * FROM `m_保険` WHERE `会社名` = '{0}' AND `営業所CD` = {1}", this.保険会社名, this.営業所CD);
                MySqlDataReader rs2;
                rs2 = DB.GetReader(myconn, query);

                if (this.営業所CD != "17")
                {
                    while (rs2.Read())
                    {
                        message.To.Add(new MimeKit.MailboxAddress(DB.NVL(rs2["EMAIL"]).ToString()));
                    }
                }
                rs2.Close();
            }
#endif

            // MimeMessageを作り、宛先やタイトルなどを設定する
            message.From.Add(new MimeKit.MailboxAddress(EMAIL_U));

            // message.Cc.Add(……省略……);
            message.Bcc.Add(new MimeKit.MailboxAddress("システム課確認用","jiko_system@ingroup.co.jp"));
            message.Subject = title;
            // MimeMessageを完成させる
            message.Body = textPart;

            // SMTPサーバに接続してメールを送信する
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                // 開発用のSMTPサーバが暗号化に対応していないときは、次の行を追加する
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                try
                {
                    await client.ConnectAsync("ingroup.co.jp", 587);
                    WriteLine("接続完了");

                    // SMTPサーバがユーザー認証を必要としない場合は、次の2行は不要
                    await client.AuthenticateAsync(userName, password);
                    WriteLine("認証完了");

                    await client.SendAsync(message);
                    WriteLine("送信完了");

                    await client.DisconnectAsync(true);
                    WriteLine("切断");
                }
                catch (Exception ex)
                {
                    WriteLine(ex.ToString());
                }
            }
        }
        public override string ToString()
        {
            // Combobox は自動でToStringを呼び出す
            return this.item1;
        }
    }
}
