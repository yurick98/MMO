namespace MultiplayerARPG.MMO
{
    public interface ICentralServerDataManager
    {
        string GenerateCharacterId();
        string GenerateMapSpawnRequestId();
        bool CanCreateCharacter(int dataId, int entityId, int factionId);
        void SetNewPlayerCharacterData(PlayerCharacterData playerCharacterData, string characterName, int dataId, int entityId, int factionId);
    }
}
