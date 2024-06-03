using Domain.Shared.Enums;
using System.ComponentModel;

namespace Application.Queries;

public class SortQuery
{
    public SortQuery()
    {
        SortField = ModelField.None;
        SortDirection = SortDirection;
    }

    public ModelField SortField { get; set; }
    public SortDirection SortDirection { get; set; }
}