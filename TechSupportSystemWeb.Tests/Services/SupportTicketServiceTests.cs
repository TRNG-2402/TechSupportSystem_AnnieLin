using Moq;
using TechSupportSystemWeb.Data;
using TechSupportSystemWeb.DTOs;
using TechSupportSystemWeb.Models;
using TechSupportSystemWeb.Services;

namespace TechSupportSystemWeb.Tests.Services;

public class SupportTicketServiceTests
{
    private readonly Mock<ISupportTicketRepo> _repoMock;

    private readonly SupportService _sut;

    public SupportTicketServiceTests()
    {
        _repoMock = new Mock<ISupportTicketRepo>();
        _sut = new SupportService(_repoMock.Object);
    }

    [Fact]
    public async Task CreateTicketAsync_ShouldCreateTestTicket_ReturnTestTicket()
    {
        var dto = new SupportTicketDTO
        {
            Title = "Test",
            Description = "Test Description"
        };
        var exp = new SupportTicket
        {
            ID = 1,
            Title = "Test",
            Description = "Test Description",
            Status = "Open",
            Priority = "Low"
        };
        _repoMock.Setup(r => r.CreateTicketAsync(It.IsAny<SupportTicket>())).ReturnsAsync(exp);

        var result = await _sut.CreateTicketAsync(dto);
        Assert.Equal("Test", result.Title);
        Assert.Equal("Test Description", result.Description);
        Assert.Equal("Open", result.Status);
        Assert.Equal("Low", result.Priority);
    }

    [Fact]
    public async Task DisplayAllTicketsAsync_NullTicket_ThrowsNullReferenceException()
    {
        _repoMock.Setup(r => r.DisplayAllTicketsAsync()).ReturnsAsync((List<SupportTicket>)null);
        await Assert.ThrowsAsync<NullReferenceException>(() => _sut.DisplayAllTicketsAsync());
    }

    [Fact]
    public async Task GetTicketsByIDAsync_InvalidID_ThrowsIDOutOfRangeException()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetTicketByIDAsync(0));
    }

    [Fact]
    public async Task UpdateTicketAsync_SomeUpdate_ReturnUpdatedTicket()
    {
        var old = new SupportTicket
        {
            ID = 1,
            Title = "Old",
            Description = "Description",
        };
        var updated = new SupportTicket
        {
            Title = "New",
            Description = "Updated"
        };
        _repoMock.Setup(r => r.GetTicketByIDAsync(1)).ReturnsAsync(old);
        _repoMock.Setup(r => r.UpdateTicketAsync(It.IsAny<SupportTicket>())).ReturnsAsync((SupportTicket t) => t);

        var result = await _sut.UpdateTicketAsync(1, updated);
        Assert.Equal("New", result.Title);
        Assert.Equal("Updated", result.Description);
        Assert.Equal("Open", result.Status);
        Assert.Equal("Low", result.Priority);
    }

    [Fact]
    public async Task DeleteTicketAsync_NoTicketFound_ThrowKeyNotFoundException()
    {
        _repoMock.Setup(r => r.GetTicketByIDAsync(1)).ReturnsAsync((SupportTicket)null);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _sut.DeleteTicketAsync(1));
    }

    
}
