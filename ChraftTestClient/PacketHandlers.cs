﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chraft.Net;
using Chraft.Net.Packets;

namespace ChraftTestClient
{
    public class PacketHandlers
    {
        private static ClientPacketHandler[] m_Handlers;

        public static ClientPacketHandler[] Handlers
        {
            get { return m_Handlers; }
        }

        static PacketHandlers()
        {
            m_Handlers = new ClientPacketHandler[0x100];

            Register(PacketType.KeepAlive, 5, 0, ReadKeepAlive);
            Register(PacketType.LoginRequest, 0, 23, ReadLoginRequest);
            Register(PacketType.Handshake, 0, 3, ReadHandshake);
            Register(PacketType.ChatMessage, 0, 3, ReadChatMessage);
            Register(PacketType.Disconnect, 0, 3, ReadDisconnect);
            Register(PacketType.PreChunk, 10, 0, ReadPreChunk);
            Register(PacketType.MapChunk, 0, 18, ReadMapChunk);
            Register(PacketType.TimeUpdate, 9, 0, ReadTimeUpdate);
            Register(PacketType.BlockChange, 12, 0, ReadBlockChange);
            Register(PacketType.MultiBlockChange, 0, 11, ReadMultiBlockChange);
            Register(PacketType.NamedEntitySpawn, 0, 23, ReadNamedEntitySpawn);
            Register(PacketType.Entity, 5, 0, ReadEntity);
            Register(PacketType.EntityLook, 7, 0, ReadEntityLook);
            Register(PacketType.EntityRelativeMove, 8, 0, ReadEntityRelativeMove);
            Register(PacketType.EntityLookAndRelativeMove, 10, 0, ReadEntityLookAndRelativeMove);
            Register(PacketType.EntityTeleport, 19, 0, ReadEntityTeleport);
            Register(PacketType.EntityStatus, 6, 0, ReadEntityStatus);
            Register(PacketType.EntityAction, 6, 0, ReadEntityAction);
            Register(PacketType.MobSpawn, 21, 0, ReadMobSpawn);
            Register(PacketType.SpawnPosition, 13, 0, ReadSpawnPosition);
            Register(PacketType.PlayerPositionRotation, 42, 0, ReadPlayerPositionRotation);
            Register(PacketType.NewInvalidState, 3, 0, ReadNewInvalidState);
            Register(PacketType.UpdateSign, 0, 11, ReadUpdateSign);
            Register(PacketType.SetSlot, 0, 6, ReadSetSlot);
            Register(PacketType.PlayerListItem, 0, 6, ReadPlayerListItem);
            Register(PacketType.UpdateHealth, 9, 0, ReadUpdateHealth);
            Register(PacketType.EntityEquipment, 11, 0, ReadEntityEquipment);
            Register(PacketType.DestroyEntity, 3, 0, ReadDestroyEntity);
            Register(PacketType.Animation, 6, 0, ReadAnimation);
        }

        public static void Register(PacketType packetID, int length, int minimumLength, OnPacketReceive onReceive)
        {
            m_Handlers[(byte)packetID] = new ClientPacketHandler(packetID, length, minimumLength, onReceive);
        }

        public static ClientPacketHandler GetHandler(PacketType packetID)
        {
            return m_Handlers[(byte)packetID];
        }

        public static void ReadKeepAlive(TestClient client, PacketReader reader)
        {
            KeepAlivePacket ka = new KeepAlivePacket();
            ka.Read(reader);

            if (!reader.Failed)
                TestClient.HandlePacketKeepAlive(client, ka);
        }

        public static void ReadLoginRequest(TestClient client, PacketReader reader)
        {
            LoginRequestPacket lr = new LoginRequestPacket();
            lr.Read(reader);

            if (!reader.Failed)
                TestClient.HandlePacketLoginRequest(client, lr);
        }

        public static void ReadHandshake(TestClient client, PacketReader reader)
        {
            HandshakePacket hp = new HandshakePacket();
            hp.Read(reader);

            if (!reader.Failed)
                TestClient.HandlePacketHandshake(client, hp);
        }

        public static void ReadChatMessage(TestClient client, PacketReader reader)
        {
            ChatMessagePacket cm = new ChatMessagePacket();
            cm.Read(reader);

            if (!reader.Failed)
                TestClient.HandlePacketChatMessage(client, cm);
        }

        public static void ReadDisconnect(TestClient client, PacketReader reader)
        {
            DisconnectPacket dp = new DisconnectPacket();
            dp.Read(reader);

            if (!reader.Failed)
                TestClient.HandlePacketDisconnect(client, dp);
        }

        public static void ReadPreChunk(TestClient client, PacketReader reader)
        {
            PreChunkPacket pc = new PreChunkPacket();
            pc.Read(reader);
        }

        public static void ReadMapChunk(TestClient client, PacketReader reader)
        {
            MapChunkPacket mc = new MapChunkPacket();
            mc.Read(reader);
        }

        public static void ReadTimeUpdate(TestClient client, PacketReader reader)
        {
            TimeUpdatePacket tu = new TimeUpdatePacket();
            tu.Read(reader);
        }

        public static void ReadBlockChange(TestClient client, PacketReader reader)
        {
            BlockChangePacket bc = new BlockChangePacket();
            bc.Read(reader);
        }

        public static void ReadMultiBlockChange(TestClient client, PacketReader reader)
        {
            MultiBlockChangePacket mbc = new MultiBlockChangePacket();
            mbc.Read(reader);
        }

        public static void ReadNamedEntitySpawn(TestClient client, PacketReader reader)
        {
            NamedEntitySpawnPacket bc = new NamedEntitySpawnPacket();
            bc.Read(reader);
        }

        public static void ReadEntity(TestClient client, PacketReader reader)
        {
            CreateEntityPacket ce = new CreateEntityPacket();
            ce.Read(reader);
        }

        public static void ReadEntityLook(TestClient client, PacketReader reader)
        {
            EntityLookPacket el = new EntityLookPacket();
            el.Read(reader);
        }

        public static void ReadEntityRelativeMove(TestClient client, PacketReader reader)
        {
            EntityRelativeMovePacket er = new EntityRelativeMovePacket();
            er.Read(reader);
        }

        public static void ReadEntityLookAndRelativeMove(TestClient client, PacketReader reader)
        {
            EntityLookAndRelativeMovePacket ela = new EntityLookAndRelativeMovePacket();
            ela.Read(reader);
        }

        public static void ReadEntityTeleport(TestClient client, PacketReader reader)
        {
            EntityTeleportPacket et = new EntityTeleportPacket();
            et.Read(reader);
        }

        public static void ReadEntityStatus(TestClient client, PacketReader reader)
        {
            EntityStatusPacket es = new EntityStatusPacket();
            es.Read(reader);
        }

        public static void ReadMobSpawn(TestClient client, PacketReader reader)
        {
            MobSpawnPacket ms = new MobSpawnPacket();
            ms.Read(reader);
        }

        public static void ReadSpawnPosition(TestClient client, PacketReader reader)
        {
            SpawnPositionPacket si = new SpawnPositionPacket();
            si.Read(reader);

            if (!reader.Failed)
                TestClient.HandlePacketSpawnPosition(client, si);
        }

        public static void ReadNewInvalidState(TestClient client, PacketReader reader)
        {
            NewInvalidStatePacket ni = new NewInvalidStatePacket();
            ni.Read(reader);
        }

        public static void ReadPlayerPositionRotation(TestClient client, PacketReader reader)
        {
            PlayerPositionRotationPacket ppr = new PlayerPositionRotationPacket();
            ppr.Read(reader);

            if (!reader.Failed)
                TestClient.HandlePacketPlayerPositionRotation(client, ppr);
        }

        public static void ReadEntityAction(TestClient client, PacketReader reader)
        {
            EntityActionPacket ea = new EntityActionPacket();
            ea.Read(reader);

            // TODO: implement this packet
            /*if (!reader.Failed)
                Client.HandlePacketEntityAction(client, ea);*/
        }

        public static void ReadUpdateSign(TestClient client, PacketReader reader)
        {
            UpdateSignPacket us = new UpdateSignPacket();
            us.Read(reader);
        }

        public static void ReadSetSlot(TestClient client, PacketReader reader)
        {
            SetSlotPacket ss = new SetSlotPacket();
            ss.Read(reader);
        }

        public static void ReadPlayerListItem(TestClient client, PacketReader reader)
        {
            PlayerListItemPacket pl = new PlayerListItemPacket();
            pl.Read(reader);
        }

        public static void ReadUpdateHealth(TestClient client, PacketReader reader)
        {
            UpdateHealthPacket uh = new UpdateHealthPacket();
            uh.Read(reader);
        }

        public static void ReadEntityEquipment(TestClient client, PacketReader reader)
        {
            EntityEquipmentPacket ee = new EntityEquipmentPacket();
            ee.Read(reader);
        }

        public static void ReadDestroyEntity(TestClient client, PacketReader reader)
        {
            DestroyEntityPacket de = new DestroyEntityPacket();
            de.Read(reader);
        }

        public static void ReadAnimation(TestClient client, PacketReader reader)
        {
            AnimationPacket ap = new AnimationPacket();
            ap.Read(reader);
        }
    }
}