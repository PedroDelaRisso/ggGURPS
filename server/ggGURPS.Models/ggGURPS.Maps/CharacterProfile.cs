using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Character, Character>();

        CreateMap<Character, PostCharacterDTO>()
            .ForMember(c => c.Name, opt => opt.MapFrom(source => source.Name))
            .ForMember(c => c.Strength, opt => opt.MapFrom(source => source.Attributes.Strength))
            .ForMember(c => c.Dexterity, opt => opt.MapFrom(source => source.Attributes.Dexterity))
            .ForMember(c => c.Inteligence, opt => opt.MapFrom(source => source.Attributes.Inteligence))
            .ForMember(c => c.Health, opt => opt.MapFrom(source => source.Attributes.Health))
            .ForMember(c => c.Perception, opt => opt.MapFrom(source => source.Attributes.Perception))
            .ForMember(c => c.Will, opt => opt.MapFrom(source => source.Attributes.Will))
            .ForMember(c => c.Magery, opt => opt.MapFrom(source => source.Attributes.Magery))
            .ForMember(c => c.DamageReduction, opt => opt.MapFrom(source => source.Attributes.DamageReduction))
            .ForMember(c => c.HitPoints, opt => opt.MapFrom(source => source.Attributes.HitPoints))
            .ForMember(c => c.FatiguePoints, opt => opt.MapFrom(source => source.Attributes.FatiguePoints))
            .ForMember(c => c.EnergyReserves, opt => opt.MapFrom(source => source.Attributes.EnergyReserves))
            .ReverseMap();
        
        CreateMap<Item, PostItemDTO>()
            .ForMember(i => i.Name, opt => opt.MapFrom(source => source.Name))
            .ForMember(i => i.Description, opt => opt.MapFrom(source => source.Description))
            .ForMember(i => i.Type, opt => opt.MapFrom(source => source.Type))
            .ForMember(i => i.SkillId, opt => opt.MapFrom(source => source.ItemStats.SkillId))
            .ForMember(i => i.DamageType, opt => opt.MapFrom(source => source.ItemStats.DamageType))
            .ForMember(i => i.DamageDice, opt => opt.MapFrom(source => source.ItemStats.DamageDice))
            .ForMember(i => i.Modifier, opt => opt.MapFrom(source => source.ItemStats.Modifier))
            .ForMember(i => i.Recoil, opt => opt.MapFrom(source => source.ItemStats.Recoil))
            .ForMember(i => i.RateOfFire, opt => opt.MapFrom(source => source.ItemStats.RateOfFire))
            .ForMember(i => i.Shots, opt => opt.MapFrom(source => source.ItemStats.Shots))
            .ForMember(i => i.ArmorDivisor, opt => opt.MapFrom(source => source.ItemStats.ArmorDivisor))
            .ForMember(i => i.Range, opt => opt.MapFrom(source => source.ItemStats.Range))
            .ReverseMap();

        CreateMap<Skill, PostSkillDTO>()
            .ForMember(s => s.Name, opt => opt.MapFrom(source => source.Name))
            .ForMember(s => s.Description, opt => opt.MapFrom(source => source.Description))
            .ForMember(s => s.BaseAttribute, opt => opt.MapFrom(source => source.BaseAttribute))
            .ForMember(s => s.Level, opt => opt.MapFrom(source => source.Level))
            .ReverseMap();
    }
}