using System;
using Xunit;
using OneIdentityAPI;
using FakeItEasy;
using Microsoft.Extensions.Options;
using MongoDB.Driver;



public class UnitTest1
{
    //run with dotnet test test-OneIdentityAPI/test-OneIdentityAPI.csproj

    [Fact]
    public async Task TestGetAsync()
    {
        //Setup
        var data = A.Fake<IMongoDBService>();
        var result = await data.GetAsync();

        //Assert True for this endpoint
        A.CallTo(() => data.GetAsync()).MustHaveHappened();
        
        //Assert False for the other endpoints
        A.CallTo(() => data.GetDBIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.CreateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateByUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveUserIDAsync()).MustNotHaveHappened();
    }

    [Fact]
    public async Task TestGetDBIDAsync()
    {
        
        //Setup
        var data = A.Fake<IMongoDBService>();
        var result = await data.GetDBIDAsync();

        //Assert True for this endpoint
        A.CallTo(() => data.GetDBIDAsync()).MustHaveHappened();
        
        //Assert False for the other endpoints
        A.CallTo(() => data.GetAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.CreateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateByUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveUserIDAsync()).MustNotHaveHappened();
    }

    [Fact]
    public async Task TestGetUserIDAsync()
    {
        
        //Setup
        var data = A.Fake<IMongoDBService>();
        var result = await data.GetUserIDAsync();

        //Assert True for this endpoint
        A.CallTo(() => data.GetUserIDAsync()).MustHaveHappened();
        
        //Assert False for the other endpoints
        A.CallTo(() => data.GetAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetDBIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.CreateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateByUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveUserIDAsync()).MustNotHaveHappened();
    }

    [Fact]
    public async Task TestCreateAsync()
    {
        
        //Setup
        var data = A.Fake<IMongoDBService>();
        await data.CreateAsync();

        //Assert True for this endpoint
        A.CallTo(() => data.CreateAsync()).MustHaveHappened();
        
        //Assert False for the other endpoints
        A.CallTo(() => data.GetAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetDBIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateByUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveUserIDAsync()).MustNotHaveHappened();
    }

    [Fact]
    public async Task TestUpdateAsync()
    {
        
        //Setup
        var data = A.Fake<IMongoDBService>();
        await data.UpdateAsync();

        //Assert True for this endpoint
        A.CallTo(() => data.UpdateAsync()).MustHaveHappened();
        
        //Assert False for the other endpoints
        A.CallTo(() => data.GetAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetDBIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.CreateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateByUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveUserIDAsync()).MustNotHaveHappened();
    }

    [Fact]
    public async Task TestUpdateByUserIDAsync()
    {
        
        //Setup
        var data = A.Fake<IMongoDBService>();
        await data.UpdateByUserIDAsync();

        //Assert True for this endpoint
        A.CallTo(() => data.UpdateByUserIDAsync()).MustHaveHappened();
        
        //Assert False for the other endpoints
        A.CallTo(() => data.GetAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetDBIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.CreateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveUserIDAsync()).MustNotHaveHappened();
    }

    [Fact]
    public async Task TestRemoveAsync()
    {
        
        //Setup
        var data = A.Fake<IMongoDBService>();
        await data.RemoveAsync();

        //Assert True for this endpoint
        A.CallTo(() => data.RemoveAsync()).MustHaveHappened();
        
        //Assert False for the other endpoints
        A.CallTo(() => data.GetAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetDBIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.CreateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateByUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveUserIDAsync()).MustNotHaveHappened();
    }

    [Fact]
    public async Task TestRemoveUserIDAsync()
    {
        
        //Setup
        var data = A.Fake<IMongoDBService>();
        await data.RemoveUserIDAsync();

        //Assert True for this endpoint
        A.CallTo(() => data.RemoveUserIDAsync()).MustHaveHappened();
        
        //Assert False for the other endpoints
        A.CallTo(() => data.GetAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetDBIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.GetUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.CreateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateAsync()).MustNotHaveHappened();
        A.CallTo(() => data.UpdateByUserIDAsync()).MustNotHaveHappened();
        A.CallTo(() => data.RemoveAsync()).MustNotHaveHappened();
    }
}