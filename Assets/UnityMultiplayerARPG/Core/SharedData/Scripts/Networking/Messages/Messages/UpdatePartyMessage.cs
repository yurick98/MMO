﻿using LiteNetLib.Utils;

namespace MultiplayerARPG
{
    [System.Serializable]
    public partial struct UpdatePartyMessage : INetSerializable
    {
        public enum UpdateType : byte
        {
            Create,
            ChangeLeader,
            Setting,
            Terminate,
            Member,
        }
        public UpdateType type;
        public int id;
        public bool shareExp;
        public bool shareItem;
        public string characterId;

        public void Deserialize(NetDataReader reader)
        {
            type = (UpdateType)reader.GetByte();
            id = reader.GetInt();
            switch (type)
            {
                case UpdateType.Create:
                    shareExp = reader.GetBool();
                    shareItem = reader.GetBool();
                    characterId = reader.GetString();
                    break;
                case UpdateType.ChangeLeader:
                    characterId = reader.GetString();
                    break;
                case UpdateType.Setting:
                    shareExp = reader.GetBool();
                    shareItem = reader.GetBool();
                    break;
            }
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)type);
            writer.Put(id);
            switch (type)
            {
                case UpdateType.Create:
                    writer.Put(shareExp);
                    writer.Put(shareItem);
                    writer.Put(characterId);
                    break;
                case UpdateType.ChangeLeader:
                    writer.Put(characterId);
                    break;
                case UpdateType.Setting:
                    writer.Put(shareExp);
                    writer.Put(shareItem);
                    break;
            }
        }
    }
}
