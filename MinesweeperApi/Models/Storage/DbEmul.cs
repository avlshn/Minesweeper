using MinesweeperApi.Models.DTO;

namespace MinesweeperApi.Models.Storage;

public class DbEmul
{

	private Dictionary<Guid, Game> _storage;

	public Dictionary<Guid, Game> Storage
    {
		get { return _storage; }
		set { _storage = value; }
	}

    public DbEmul()
    {
        _storage = new Dictionary<Guid, Game>();
    }

}
