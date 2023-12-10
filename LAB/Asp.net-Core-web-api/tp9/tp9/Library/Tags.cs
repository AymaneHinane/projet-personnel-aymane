using System;
namespace test8.Model.Library
{
	public class Tags
	{
        public string TagsId { get; set; }
        public ICollection<Books>? Books { get; set; }
    }
}

