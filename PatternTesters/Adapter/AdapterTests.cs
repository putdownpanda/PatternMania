using Xunit;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using HorseBettingNotifications.Core.Data;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Input;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Output;
using HorseBettingNotifications.Patterns.Factory;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;

namespace PatternTesters.Adapter;
public class AdapterTests
{
    private readonly IDbContextFactory<HBDbContext> _contextFactory;

    public AdapterTests()
    {
        SQLitePCL.Batteries.Init();
        _contextFactory = new HBDbContextFactory();
    }

    private const string SampleJson = @"
    [
      {
        ""Ulid"": ""01HXJ6YKEGRAJPXT9RSCJ3E1XR"",
        ""Amount"": 100,
        ""PlacedAt"": ""2024-04-14T12:00:00Z"",
        ""UserUlid"": ""01HXJ6YKEGRAJPXT9RSCJ3E1XU"",
        ""Races"": ""01HXJ6YKEGRXYZ1RSCJ3ABCDEF"",
        ""Runners"": ""01HXJ6YKEGRAJPXT9RSCJ3E1ZZ"",
        ""BetTypeUlid"": ""01HXJ6YKEGRATYPE999999999""
      }
    ]";
    private const string SampleXml = @"
    <ArrayOfBet xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
      <Bet>
        <Ulid>01HXJ6YKEGRAJPXT9RSCJ3E1XR</Ulid>
        <Amount>200</Amount>
        <PlacedAt>2024-04-14T12:00:00Z</PlacedAt>
        <UserUlid>01HXJ6YKEGRAJPXT9RSCJ3E1XU</UserUlid>
        <Races>01HXJ6YKEGRXYZ1RSCJ3ABCDEF</Races>
        <Runners>01HXJ6YKEGRAJPXT9RSCJ3E1ZZ</Runners>
        <BetTypeUlid>01HXJ6YKEGRATYPE999999999</BetTypeUlid>
      </Bet>
    </ArrayOfBet>";

    [Fact]
    public void JsonAdapterParsesBetsCorrectly()
    {
        var adapter = new JsonBetAdapter(SampleJson);

        var bets = adapter.GetBets().ToList();

        Assert.Single(bets);
        Assert.Equal("01HXJ6YKEGRAJPXT9RSCJ3E1XR", bets[0].Ulid);
        Assert.Equal(100, bets[0].Amount);
    }

    [Fact]
    public void XmlAdapterParsesBetsCorrectly()
    {
        var adapter = new XmlBetAdapter(SampleXml);

        var bets = adapter.GetBets().ToList();

        Assert.Single(bets);
        Assert.Equal("01HXJ6YKEGRAJPXT9RSCJ3E1XR", bets[0].Ulid);
        Assert.Equal(200, bets[0].Amount);
    }

    [Fact]
    public void DbAdapterReturnsBetsFromContext()
    {
        using var context = _contextFactory.CreateDbContext();

        var user = context.Users.FirstOrDefault();
        var betType = context.BetTypes.FirstOrDefault();

        var newBet = new Bet
        {
            Amount = 123,
            UserUlid = user.Ulid,
            Races = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Runners = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            BetTypeUlid = betType.Ulid
        };

        context.Bets.Add(newBet);
        context.SaveChanges();

        var adapter = new DbBetAdapter(context);
        var bets = adapter.GetBets().ToList();
        var betFound = bets.FirstOrDefault(b => b.Ulid == newBet.Ulid);

        Assert.NotNull(betFound);
    }

    [Fact]
    public void JsonWriterSerializesBet()
    {
        var bet = new Bet
        {
            Amount = 777,
            UserUlid = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Races = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Runners = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            BetTypeUlid = System.Ulid.NewUlid(DateTime.UtcNow).ToString()
        };

        var writer = new JsonBetWriter();
        writer.WriteBet(bet); 
    }

    [Fact]
    public void XmlWriterSerializesBet()
    {
        var bet = new Bet
        {
            Amount = 888,
            UserUlid = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Races = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Runners = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            BetTypeUlid = System.Ulid.NewUlid(DateTime.UtcNow).ToString()
        };

        var writer = new XmlBetWriter();
        writer.WriteBet(bet); 
    }
}
