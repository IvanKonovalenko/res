public interface IDbSessionDAL
{
    Task<SessionModel?>GetSession(Guid sessionId);
    Task<int> UpdateSession(SessionModel session);
    Task<int> CreateSession(SessionModel session);
}