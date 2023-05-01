using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Util;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Index.Extensions;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.LuceneDto;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Repositories
{
    public class LuceneSearch : ILuceneSearch
    {
        public void AddDocumentToLucene(Place place)
        {
            using (var _directory = FSDirectory.Open(new DirectoryInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "LuceneData"))))
            {
                const LuceneVersion version = LuceneVersion.LUCENE_48;
                CharArraySet stopSet = CharArraySet.Copy(LuceneVersion.LUCENE_48, StandardAnalyzer.STOP_WORDS_SET);
                stopSet.Add("و");
                stopSet.Add("که");
                stopSet.Add("از");
                stopSet.Add("برای");
                stopSet.Add("است");
                stopSet.Add("هست");
                StandardAnalyzer _analyzer = new StandardAnalyzer(version, stopSet);
                var config = new IndexWriterConfig(version, _analyzer);
                IndexWriter _writer = new IndexWriter(_directory, config);
                var document = new Document
                {
                    new StringField("Id", place.Id.ToString(), Field.Store.YES),
                    new TextField("tablo", place.tablo, Field.Store.YES),
                    new StringField("manager",place.manager, Field.Store.YES),
                    new StringField("taparcode", place.taparcode ?? "null", Field.Store.YES),
                    new TextField("service_description", place.service_description ?? "null", Field.Store.YES),
                    new StringField("mob1", place.mob1 ?? "null", Field.Store.YES),
                    new StringField("mob2", place.mob2 ?? "null", Field.Store.YES),
                    new StringField("phone1", place.phone1 ?? "null", Field.Store.YES),
                    new StringField("phone2", place.phone2 ?? "null", Field.Store.YES),
                    new StringField("phone3", place.phone3 ?? "null", Field.Store.YES),
                    new StringField("fax", place.fax ?? "null", Field.Store.YES),
                    new StringField("website", place.website ?? "null", Field.Store.YES),
                    new StringField("email", place.email ?? "null", Field.Store.YES),
                    new StringField("telegram", place.telegram ?? "null", Field.Store.YES),
                    new StringField("instagram", place.instagram ?? "null", Field.Store.YES),
                    new StringField("whatsapp", place.whatsapp ?? "null", Field.Store.YES),
                    new StringField("address", place.address ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic1", place.bussiness_pic1 ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic2", place.bussiness_pic2 ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic3", place.bussiness_pic3 ?? "null", Field.Store.YES),
                    new StringField("personal_pic", place.personal_pic ?? "null", Field.Store.YES),
                    new StringField("visitCart_front", place.visitCart_front ?? "null", Field.Store.YES),
                    new StringField("visitCart_back", place.visitCart_back ?? "null", Field.Store.YES),
                    new StringField("special_message", place.special_message ?? "null", Field.Store.YES),
                    new StringField("like_count",place.like_count.ToString() ?? "0",Field.Store.YES),
                    new StringField("view_count",place.view_count.ToString() ?? "0",Field.Store.YES),
                    new StringField("on_off",place.on_off==true?"true":"false",Field.Store.YES),
                    new StringField("locationId",place.locationId.ToString(),Field.Store.YES),
                    new StringField("statusId",place.StatusId.ToString(),Field.Store.YES),
                    new StringField("saturday",place.weekDay is not null?place.weekDay.saturday.ToString():"0",Field.Store.YES),
                    new StringField("sunday",place.weekDay is not null?place.weekDay.sunday.ToString() : "0",Field.Store.YES),
                    new StringField("monday",place.weekDay is not null?place.weekDay.monday.ToString(): "0",Field.Store.YES),
                    new StringField("tuesday",place.weekDay is not null?place.weekDay.tuesday.ToString() : "0",Field.Store.YES),
                    new StringField("wednesday",place.weekDay is not null?place.weekDay.wednesday.ToString() : "0",Field.Store.YES),
                    new StringField("thursday",place.weekDay is not null?place.weekDay.thursday.ToString() : "0",Field.Store.YES),
                    new StringField("friday",place.weekDay is not null?place.weekDay.friday.ToString() : "0",Field.Store.YES),
                    new StringField("userId", place.userId.ToString(), Field.Store.YES),
                    new StringField("workTimeId", place.workTimeId.ToString(), Field.Store.YES),
                };
                _writer.AddDocument(document);
                _writer.Commit();
                _writer.Flush(true, true);
                _writer.Dispose();
                _directory.Dispose();
                _analyzer.Dispose();
            }

        }

        public void EditPlace(Place place)
        {
            var d = new Document()
            {
                    new StringField("Id", place.Id.ToString(), Field.Store.YES),
                    new TextField("tablo", place.tablo, Field.Store.YES),
                    new StringField("manager",place.manager, Field.Store.YES),
                    new StringField("taparcode", place.taparcode ?? "null", Field.Store.YES),
                    new TextField("service_description", place.service_description ?? "null", Field.Store.YES),
                    new StringField("mob1", place.mob1 ?? "null", Field.Store.YES),
                    new StringField("mob2", place.mob2 ?? "null", Field.Store.YES),
                    new StringField("phone1", place.phone1 ?? "null", Field.Store.YES),
                    new StringField("phone2", place.phone2 ?? "null", Field.Store.YES),
                    new StringField("phone3", place.phone3 ?? "null", Field.Store.YES),
                    new StringField("fax", place.fax ?? "null", Field.Store.YES),
                    new StringField("website", place.website ?? "null", Field.Store.YES),
                    new StringField("email", place.email ?? "null", Field.Store.YES),
                    new StringField("telegram", place.telegram ?? "null", Field.Store.YES),
                    new StringField("instagram", place.instagram ?? "null", Field.Store.YES),
                    new StringField("whatsapp", place.whatsapp ?? "null", Field.Store.YES),
                    new StringField("address", place.address ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic1", place.bussiness_pic1 ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic2", place.bussiness_pic2 ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic3", place.bussiness_pic3 ?? "null", Field.Store.YES),
                    new StringField("personal_pic", place.personal_pic ?? "null", Field.Store.YES),
                    new StringField("visitCart_front", place.visitCart_front ?? "null", Field.Store.YES),
                    new StringField("visitCart_back", place.visitCart_back ?? "null", Field.Store.YES),
                    new StringField("special_message", place.special_message ?? "null", Field.Store.YES),
                    new StringField("like_count",place.like_count.ToString() ?? "0",Field.Store.YES),
                    new StringField("view_count",place.view_count.ToString() ?? "0",Field.Store.YES),
                    new StringField("on_off",place.on_off==true?"true":"false",Field.Store.YES),
                    new StringField("locationId",place.locationId.ToString(),Field.Store.YES),
                    new StringField("statusId",place.StatusId.ToString(),Field.Store.YES),
                    new StringField("saturday",place.weekDay is not null?place.weekDay.saturday.ToString():"0",Field.Store.YES),
                    new StringField("sunday",place.weekDay is not null?place.weekDay.sunday.ToString() : "0",Field.Store.YES),
                    new StringField("monday",place.weekDay is not null?place.weekDay.monday.ToString(): "0",Field.Store.YES),
                    new StringField("tuesday",place.weekDay is not null?place.weekDay.tuesday.ToString() : "0",Field.Store.YES),
                    new StringField("wednesday",place.weekDay is not null?place.weekDay.wednesday.ToString() : "0",Field.Store.YES),
                    new StringField("thursday",place.weekDay is not null?place.weekDay.thursday.ToString() : "0",Field.Store.YES),
                    new StringField("friday",place.weekDay is not null?place.weekDay.friday.ToString() : "0",Field.Store.YES),
                    new StringField("userId", place.userId.ToString(), Field.Store.YES),
                    new StringField("workTimeId", place.workTimeId.ToString(), Field.Store.YES),
            };
            using (var _directory = FSDirectory.Open(new DirectoryInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "LuceneData"))))
            {
                const LuceneVersion version = LuceneVersion.LUCENE_48;
                CharArraySet stopSet = CharArraySet.Copy(LuceneVersion.LUCENE_48, StandardAnalyzer.STOP_WORDS_SET);
                stopSet.Add("و");
                stopSet.Add("که");
                stopSet.Add("از");
                stopSet.Add("برای");
                stopSet.Add("است");
                stopSet.Add("هست");
                StandardAnalyzer _analyzer = new StandardAnalyzer(version, stopSet);
                var config = new IndexWriterConfig(version, _analyzer);
                IndexWriter _writer = new IndexWriter(_directory, config);   
                Term term = new Term("Id", place.Id.ToString());
                _writer.UpdateDocument(term, d);
                _writer.Commit();
                _writer.Flush(true, true);
                _writer.Dispose();
                _directory.Dispose();
                _analyzer.Dispose();
            }
        }

        public void CopyDataToLucene(List<Place> places)
        {
            using (var _directory = FSDirectory.Open(new DirectoryInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "LuceneData"))))
            {
                const LuceneVersion version = LuceneVersion.LUCENE_48;
                CharArraySet stopSet = CharArraySet.Copy(LuceneVersion.LUCENE_48, StandardAnalyzer.STOP_WORDS_SET);
                stopSet.Add("و");
                stopSet.Add("که");
                stopSet.Add("از");
                stopSet.Add("برای");
                stopSet.Add("است");
                stopSet.Add("هست");
                StandardAnalyzer _analyzer = new StandardAnalyzer(version, stopSet);
                var config = new IndexWriterConfig(version, _analyzer);
                using (IndexWriter _writer = new IndexWriter(_directory, config))
                {
                    foreach (var place in places)
                    {
                        var document = new Document
                {
                    new StringField("Id", place.Id.ToString(), Field.Store.YES),
                    new TextField("tablo", place.tablo, Field.Store.YES),
                    new TextField("manager",place.manager, Field.Store.YES),
                    new StringField("taparcode", place.taparcode ?? "null", Field.Store.YES),
                    new StringField("service_description", place.service_description ?? "null", Field.Store.YES),
                    new StringField("mob1", place.mob1 ?? "null", Field.Store.YES),
                    new StringField("mob2", place.mob2 ?? "null", Field.Store.YES),
                    new StringField("phone1", place.phone1 ?? "null", Field.Store.YES),
                    new StringField("phone2", place.phone2 ?? "null", Field.Store.YES),
                    new StringField("phone3", place.phone3 ?? "null", Field.Store.YES),
                    new StringField("fax", place.fax ?? "null", Field.Store.YES),
                    new StringField("website", place.website ?? "null", Field.Store.YES),
                    new StringField("email", place.email ?? "null", Field.Store.YES),
                    new StringField("telegram", place.telegram ?? "null", Field.Store.YES),
                    new StringField("instagram", place.instagram ?? "null", Field.Store.YES),
                    new StringField("whatsapp", place.whatsapp ?? "null", Field.Store.YES),
                    new StringField("address", place.address ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic1", place.bussiness_pic1 ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic2", place.bussiness_pic2 ?? "null", Field.Store.YES),
                    new StringField("bussiness_pic3", place.bussiness_pic3 ?? "null", Field.Store.YES),
                    new StringField("personal_pic", place.personal_pic ?? "null", Field.Store.YES),
                    new StringField("visitCart_front", place.visitCart_front ?? "null", Field.Store.YES),
                    new StringField("visitCart_back", place.visitCart_back ?? "null", Field.Store.YES),
                    new StringField("special_message", place.special_message ?? "null", Field.Store.YES),
                    new Int32Field("like_count",place.like_count ?? 0,Field.Store.YES),
                    new Int32Field("view_count",place.view_count ?? 0,Field.Store.YES),
                    new StringField("on_off",place.on_off==true?"true":"false",Field.Store.YES),
                    new Int32Field("locationId",place.locationId,Field.Store.YES),
                    new Int32Field("statusId",place.StatusId,Field.Store.YES),
                    new Int32Field("saturday",place.weekDay is not null?place.weekDay.saturday:0,Field.Store.YES),
                    new Int32Field("sunday",place.weekDay is not null?place.weekDay.sunday:0,Field.Store.YES),
                    new Int32Field("monday",place.weekDay is not null?place.weekDay.monday:0,Field.Store.YES),
                    new Int32Field("tuesday",place.weekDay is not null?place.weekDay.tuesday:0,Field.Store.YES),
                    new Int32Field("wednesday",place.weekDay is not null?place.weekDay.wednesday:0,Field.Store.YES),
                    new Int32Field("thursday",place.weekDay is not null?place.weekDay.thursday:0,Field.Store.YES),
                    new Int32Field("friday",place.weekDay is not null?place.weekDay.friday:0,Field.Store.YES),
                    new Int64Field("userId", place.userId, Field.Store.YES),
                    new Int32Field("workTimeId", place.workTimeId, Field.Store.YES),

                };
                        _writer.AddDocument(document);
                    }
                    _writer.Commit();
                    _writer.Flush(true, true);
                    _writer.Dispose();
                }
                _directory.Dispose();
                _analyzer.Dispose();
            }

        }

        public IEnumerable<LuceneDto> Search(SearchParams searchParams)
        {
            var _directory = FSDirectory.Open(new DirectoryInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "LuceneData")));
            var directoryReader = DirectoryReader.Open(_directory);
            var indexSearcher = new IndexSearcher(directoryReader);
            var query = new BooleanQuery();
            var query2 = new BooleanQuery();
            var query3 = new BooleanQuery();

            if (searchParams.searchKey != null)
            {
                searchParams.searchKey = searchParams.searchKey.Trim().Replace("  ", " ").Replace("*", "");
                var parts = searchParams.searchKey?.Split(' ');
                foreach (var part in parts)
                {
                    query.Add(new FuzzyQuery(new Term("tablo", part), 1), Occur.SHOULD);
                    query.Add(new FuzzyQuery(new Term("service_description", part), 1), Occur.SHOULD);
                    query.Add(new WildcardQuery(new Term("tablo", $"{'*' + part + '*'}")), Occur.SHOULD);
                    query.Add(new WildcardQuery(new Term("service_description", $"{'*' + part + '*'}")), Occur.SHOULD);
                }
            }
            if (searchParams.cityId > 0)
            {

                Term term = new Term("locationId", searchParams.cityId.ToString());
                query2.Add(new TermQuery(term), Occur.MUST);
                query3.Add(query2, Occur.MUST);
            }
            else
                query3.Add(query2, Occur.SHOULD);

            query3.Add(query, Occur.MUST);

            var hits = indexSearcher.Search(query3, int.MaxValue, Sort.RELEVANCE).ScoreDocs.Skip((searchParams.pageIndex - 1) * 5).Take(5);
            var places = new List<LuceneDto>();
            foreach (var hit in hits)
            {
                var document = indexSearcher.Doc(hit.Doc);
                places.Add(new LuceneDto
                {
                    tablo = document.Get("tablo"),
                    service_description = document.Get("service_description"),
                    Id = Int64.Parse(document.Get("Id")),
                    address = document.Get("address"),
                    bussiness_pic1 = document.Get("bussiness_pic1"),
                    bussiness_pic2 = document.Get("bussiness_pic2"),
                    bussiness_pic3 = document.Get("bussiness_pic3"),
                    email = document.Get("email"),
                    fax = document.Get("fax"),
                    instagram = document.Get("instagram"),
                    telegram = document.Get("telegram"),
                    whatsapp = document.Get("whatsapp"),
                    website = document.Get("website"),
                    mob1 = document.Get("mob1"),
                    mob2 = document.Get("mob2"),
                    phone1 = document.Get("phone1"),
                    phone2 = document.Get("phone2"),
                    phone3 = document.Get("phone3"),
                    personal_pic = document.Get("personal_pic"),
                    visitCart_front = document.Get("visitCart_front"),
                    visitCart_back = document.Get("visitCart_back"),
                    manager = document.Get("manager"),
                    like_count = int.Parse(document.Get("like_count")),
                    view_count = int.Parse(document.Get("view_count")),
                    locationId = int.Parse(document.Get("locationId")),
                    userId = Int64.Parse(document.Get("userId")),
                    StatusId = int.Parse(document.Get("statusId")),
                    on_off = document.Get("on_off"),
                    special_message = document.Get("special_message"),
                    taparcode = document.Get("taparcode"),
                    workTimeId = int.Parse(document.Get("workTimeId")),
                    saturday = int.Parse(document.Get("saturday")),
                    sunday = int.Parse(document.Get("sunday")),
                    monday = int.Parse(document.Get("monday")),
                    tuesday = int.Parse(document.Get("tuesday")),
                    wednesday = int.Parse(document.Get("wednesday")),
                    thursday = int.Parse(document.Get("thursday")),
                    friday = int.Parse(document.Get("friday"))

                });
            }
            _directory.Dispose();
            return places;
        }
        public IEnumerable<LuceneDto> SearchForMobile(SearchParamsForMobile searchParams)
        {
            var _directory = FSDirectory.Open(new DirectoryInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "LuceneData")));
            var directoryReader = DirectoryReader.Open(_directory);
            var indexSearcher = new IndexSearcher(directoryReader);
            var query = new BooleanQuery();
            var query2 = new BooleanQuery();
            var query3 = new BooleanQuery();

            if (searchParams.searchKey != null)
            {
                searchParams.searchKey = searchParams.searchKey.Trim().Replace("  ", " ").Replace("*", "");
                var parts = searchParams.searchKey?.Split(' ');
                foreach (var part in parts)
                {
                    query.Add(new FuzzyQuery(new Term("tablo", part), 1), Occur.SHOULD);
                    query.Add(new FuzzyQuery(new Term("service_description", part), 1), Occur.SHOULD);
                    query.Add(new WildcardQuery(new Term("tablo", $"{'*' + part + '*'}")), Occur.SHOULD);
                    query.Add(new WildcardQuery(new Term("service_description", $"{'*' + part + '*'}")), Occur.SHOULD);
                }
            }
            if (searchParams.cityId > 0)
            {

                Term term = new Term("locationId", searchParams.cityId.ToString());
                query2.Add(new TermQuery(term), Occur.MUST);
                query3.Add(query2, Occur.MUST);
            }
            else
                query3.Add(query2, Occur.SHOULD);

            query3.Add(query, Occur.MUST);

            var hits = indexSearcher.Search(query3, int.MaxValue, Sort.RELEVANCE).ScoreDocs;
            var places = new List<LuceneDto>();
            foreach (var hit in hits)
            {
                var document = indexSearcher.Doc(hit.Doc);
                places.Add(new LuceneDto
                {
                    tablo = document.Get("tablo"),
                    service_description = document.Get("service_description"),
                    Id = Int64.Parse(document.Get("Id")),
                    address = document.Get("address"),
                    bussiness_pic1 = document.Get("bussiness_pic1"),
                    bussiness_pic2 = document.Get("bussiness_pic2"),
                    bussiness_pic3 = document.Get("bussiness_pic3"),
                    email = document.Get("email"),
                    fax = document.Get("fax"),
                    instagram = document.Get("instagram"),
                    telegram = document.Get("telegram"),
                    whatsapp = document.Get("whatsapp"),
                    website = document.Get("website"),
                    mob1 = document.Get("mob1"),
                    mob2 = document.Get("mob2"),
                    phone1 = document.Get("phone1"),
                    phone2 = document.Get("phone2"),
                    phone3 = document.Get("phone3"),
                    personal_pic = document.Get("personal_pic"),
                    visitCart_front = document.Get("visitCart_front"),
                    visitCart_back = document.Get("visitCart_back"),
                    manager = document.Get("manager"),
                    like_count = int.Parse(document.Get("like_count")),
                    view_count = int.Parse(document.Get("view_count")),
                    locationId = int.Parse(document.Get("locationId")),
                    userId = Int64.Parse(document.Get("userId")),
                    StatusId = int.Parse(document.Get("statusId")),
                    on_off = document.Get("on_off"),
                    special_message = document.Get("special_message"),
                    taparcode = document.Get("taparcode"),
                    workTimeId = int.Parse(document.Get("workTimeId")),
                    saturday = int.Parse(document.Get("saturday")),
                    sunday = int.Parse(document.Get("sunday")),
                    monday = int.Parse(document.Get("monday")),
                    tuesday = int.Parse(document.Get("tuesday")),
                    wednesday = int.Parse(document.Get("wednesday")),
                    thursday = int.Parse(document.Get("thursday")),
                    friday = int.Parse(document.Get("friday"))

                });
            }
            _directory.Dispose();
            return places;
        }
        public void DeletePlace(long placeid)
        {
            using (var _directory = FSDirectory.Open(new DirectoryInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "LuceneData"))))
            {
                const LuceneVersion version = LuceneVersion.LUCENE_48;
                StandardAnalyzer _analyzer = new StandardAnalyzer(version);
                var config = new IndexWriterConfig(version, _analyzer);
                IndexWriter _writer = new IndexWriter(_directory, config);
                _writer.DeleteDocuments(new Term("Id", placeid.ToString()));
                _writer.Commit();
                _writer.Flush(true, true);
                _writer.Dispose();
                _directory.Dispose();
                _analyzer.Dispose();
            }
        }
    }
}