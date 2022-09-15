using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_task.Models
{
    public class PaginationMetadata
    {
        public PaginationMetadata(int totalCount, int currentPage, int itemsPerPage)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            if(((int)Math.Ceiling(totalCount / (double)itemsPerPage) > 0))
                TotalPages = (int)Math.Ceiling(totalCount / (double)itemsPerPage);
        }

        public int CurrentPage { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; } = 1;
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}