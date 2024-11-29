public interface IDbSessionDAL
{
    Task<SessionModel?>Get(Guid sessionId);
    Task<int> Update(SessionModel session);
    Task<int> Create(SessionModel session);
     Task Lock(Guid sessionId);
}