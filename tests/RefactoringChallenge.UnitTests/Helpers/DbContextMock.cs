using Microsoft.EntityFrameworkCore;
using Moq;

namespace RefactoringChallenge.UnitTests.Helpers;

public static class DbContextMock
{
    /// <summary>
    /// You can use this method to setup a mock DbSet with some data
    /// </summary>
    /// <param name="sourceList">The list of entities</param>
    /// <typeparam name="T">Type of the entity</typeparam>
    /// <returns>A DbSet filled with the data on the sourceList</returns>
    public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T: class 
    {
        var queryable = sourceList.AsQueryable();
        var dbSet = new Mock<DbSet<T>>();
        dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
        dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
        return dbSet.Object;
    }
}