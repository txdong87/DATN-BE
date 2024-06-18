using Application.Queries;
using Domain.Shared.Enums;

namespace Application.DTOs.Users.GetListUsers;

public class GetListUsersRequest
{
    public GetListUsersRequest(
        string fullName,
        PagingQuery pagingQuery,
        SortQuery sortQuery,
        FilterQuery filterQuery,
        SearchQuery searchQuery)
    {
        PagingQuery = pagingQuery;
        SortQuery = sortQuery;
        FilterQuery = filterQuery;
        SearchQuery = searchQuery;
        fullName = fullName;
    }

    public PagingQuery PagingQuery { get; set; }

    public SortQuery SortQuery { get; set; }

    public FilterQuery FilterQuery { get; set; }

    public SearchQuery SearchQuery { get; set; }
    public string fullName { get; set; }

}