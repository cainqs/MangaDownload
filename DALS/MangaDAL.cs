using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALS
{
    public class MangaDAL : BaseRepository
    {
        public MangaDAL() : base(@".\SettingDB.db")
        {
        }

        public MangaSetting GetMangaSetting()
        {
            var sql = "SELECT * FROM Setting";

            return QuerySingleOrDefault<MangaSetting>(sql);
        }

        public int InserMangaSetting(MangaSetting entity)
        {
            var sql = @"INSERT INTO Setting (MangaFolder, ZipFolder, IsZip) VALUES (@MangaFolder, @ZipFolder, @IsZip)";

            return Execute(sql, entity);
        }

        public int UpdateMangaSetting(MangaSetting entity)
        {
            var sql = @"UPDATE Setting SET MangaFolder = @MangaFolder, ZipFolder = @ZipFolder, IsZip = @IsZip";

            return Execute(sql, entity);
        }

        public List<MangaHistory> GetMangaHistory(string mangaSite)
        {
            var sql = @"SELECT * FROM History WHERE MangaSite = @mangaSite";

            return Query<MangaHistory>(sql, new { mangaSite });
        }

        public int InsertMangaHistory(MangaHistory entity)
        {
            var sql = @"INSERT INTO History (MangaSite, MangaName, LastDownloadTimeStr, Downloaded, MangaUrl)
                            VALUES (@MangaSite, @MangaName, @LastDownloadTimeStr, @Downloaded, @MangaUrl)";

            return Execute(sql, entity);
        }

        public int UpdateMangaHistory(MangaHistory entity)
        {
            var sql = "UPDATE History SET LastDownLoadTimeStr = @LastDownloadTimeStr, Downloaded = @Downloaded WHERE MangaSite = @MangaSite AND MangaName = @MangaName";

            return Execute(sql, entity);
        }
    }
}
