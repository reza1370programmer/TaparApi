

using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Tapar.Core.Common.Dtos.LuceneDto;
using Tapar.Core.Contracts.Interfaces;

namespace Tapar.Core.Contracts.Repositories
{
    public class LuceneSearch : ILuceneSearch
    {
        const LuceneVersion version = LuceneVersion.LUCENE_48;
        private readonly StandardAnalyzer _analyzer;
        private readonly Lucene.Net.Store.Directory _directory;
        //private readonly IndexWriter _writer;
        //public IPlaceRepository PlaceRepository { get; set; }
        public LuceneSearch()
        {
            _analyzer = new StandardAnalyzer(version);
            _directory = FSDirectory.Open(new System.IO.DirectoryInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "LuceneData")));
            var config = new IndexWriterConfig(version, _analyzer);
            //_writer = new IndexWriter(_directory, config);
            //PlaceRepository = placeRepository;
        }

        public void AddPlacesToIndex()
        {
            throw new NotImplementedException();
        }

        //public void CopyDataToLucene()
        //{
        //    var persons = PlaceRepository.TableNoTracking.Include(p => p.weekDay).ToList();
        //    foreach (var person in persons)
        //    {
        //        var document = new Document
        //        {
        //            new Int64Field("Id", person.Id, Field.Store.YES),
        //            new TextField("tablo", person.tablo, Field.Store.YES),
        //            new TextField("manager", person.manager, Field.Store.YES),
        //            new StringField("taparcode", person.taparcode ?? "null", Field.Store.YES),
        //            new StringField("service_description", person.service_description ?? "null", Field.Store.YES),
        //            new StringField("mob1", person.mob1 ?? "null", Field.Store.YES),
        //            new StringField("mob2", person.mob2 ?? "null", Field.Store.YES),
        //            new StringField("phone1", person.phone1 ?? "null", Field.Store.YES),
        //            new StringField("phone2", person.phone2 ?? "null", Field.Store.YES),
        //            new StringField("phone3", person.phone3 ?? "null", Field.Store.YES),
        //            new StringField("fax", person.fax ?? "null", Field.Store.YES),
        //            new StringField("website", person.website ?? "null", Field.Store.YES),
        //            new StringField("email", person.email ?? "null", Field.Store.YES),
        //            new StringField("telegram", person.telegram ?? "null", Field.Store.YES),
        //            new StringField("instagram", person.instagram ?? "null", Field.Store.YES),
        //            new StringField("whatsapp", person.whatsapp ?? "null", Field.Store.YES),
        //            new StringField("address", person.address ?? "null", Field.Store.YES),
        //            new StringField("bussiness_pic1", person.bussiness_pic1 ?? "null", Field.Store.YES),
        //            new StringField("bussiness_pic2", person.bussiness_pic2 ?? "null", Field.Store.YES),
        //            new StringField("bussiness_pic3", person.bussiness_pic3 ?? "null", Field.Store.YES),
        //            new StringField("personal_pic", person.personal_pic ?? "null", Field.Store.YES),
        //            new StringField("visitCart_front", person.visitCart_front ?? "null", Field.Store.YES),
        //            new StringField("visitCart_back", person.visitCart_back ?? "null", Field.Store.YES),
        //            new StringField("special_message", person.special_message ?? "null", Field.Store.YES),
        //            new Int32Field("like_count",person.like_count ?? 0,Field.Store.YES),
        //            new Int32Field("view_count",person.view_count ?? 0,Field.Store.YES),
        //            new StringField("on_off",person.on_off==true?"true":"false",Field.Store.YES),
        //            new Int32Field("locationId",person.locationId,Field.Store.YES),
        //            new Int32Field("StatusId",person.StatusId,Field.Store.YES),
        //            new Int32Field("saturday",person.weekDay is not null?person.weekDay.saturday:0,Field.Store.YES),
        //            new Int32Field("sunday",person.weekDay is not null?person.weekDay.sunday:0,Field.Store.YES),
        //            new Int32Field("monday",person.weekDay is not null?person.weekDay.monday:0,Field.Store.YES),
        //            new Int32Field("tuesday",person.weekDay is not null?person.weekDay.tuesday:0,Field.Store.YES),
        //            new Int32Field("wednesday",person.weekDay is not null?person.weekDay.wednesday:0,Field.Store.YES),
        //            new Int32Field("thursday",person.weekDay is not null?person.weekDay.thursday:0,Field.Store.YES),
        //            new Int32Field("friday",person.weekDay is not null?person.weekDay.friday:0,Field.Store.YES),
        //            new Int64Field("userId", person.userId, Field.Store.YES),
        //            new Int32Field("workTimeId", person.workTimeId, Field.Store.YES),

        //        };
        //        _writer.AddDocument(document);
        //    }
        //    _writer.Commit();
        //    _writer.Dispose();
        //}

        public IEnumerable<LuceneDto> Search(string searchTerm)
        {
            var directoryReader = DirectoryReader.Open(_directory);
            var indexSearcher = new IndexSearcher(directoryReader);
            string[] fields = { "tablo", "service_description" };
            var queryParser = new MultiFieldQueryParser(version, fields, _analyzer);
            //var query = queryParser.Parse(searchTerm);
            var query = new BooleanQuery();
            var parts = searchTerm.Split(' ');
            foreach (var part in parts)
            {
                query.Add(new FuzzyQuery(new Term("tablo", part),1), Occur.SHOULD);
                query.Add(new FuzzyQuery(new Term("service_description", part),1), Occur.SHOULD);
            }

            var hits = indexSearcher.Search(query, 20).ScoreDocs;
            var places = new List<LuceneDto>();
            foreach (var hit in hits)
            {
                var document = indexSearcher.Doc(hit.Doc);
                places.Add(new LuceneDto
                {
                    tablo = document.Get("tablo"),
                    service_description = document.Get("service_description"),
                    Id = int.Parse(document.Get("Id")),
                });
            }
            return places;
        }
    }
}
