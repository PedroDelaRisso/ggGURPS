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
            .ForMember(c => c.Strength, opt => opt.MapFrom(source => source.Strength))
            .ForMember(c => c.Dexterity, opt => opt.MapFrom(source => source.Dexterity))
            .ForMember(c => c.Inteligence, opt => opt.MapFrom(source => source.Inteligence))
            .ForMember(c => c.Health, opt => opt.MapFrom(source => source.Health))
            .ForMember(c => c.Perception, opt => opt.MapFrom(source => source.Perception))
            .ForMember(c => c.Will, opt => opt.MapFrom(source => source.Will))
            .ForMember(c => c.Magery, opt => opt.MapFrom(source => source.Magery))
            .ForMember(c => c.DamageReduction, opt => opt.MapFrom(source => source.DamageReduction))
            .ForMember(c => c.HitPoints, opt => opt.MapFrom(source => source.HitPoints))
            .ForMember(c => c.FatiguePoints, opt => opt.MapFrom(source => source.FatiguePoints))
            .ForMember(c => c.EnergyReserves, opt => opt.MapFrom(source => source.EnergyReserves))
            .ReverseMap();

        CreateMap<Item, Item>();
        
        CreateMap<Item, PostItemDTO>()
            .ForMember(i => i.Name, opt => opt.MapFrom(source => source.Name))
            .ForMember(i => i.Description, opt => opt.MapFrom(source => source.Description))
            .ForMember(i => i.Type, opt => opt.MapFrom(source => source.Type))
            .ForMember(i => i.SkillId, opt => opt.MapFrom(source => source.SkillId))
            .ForMember(i => i.DamageType, opt => opt.MapFrom(source => source.DamageType))
            .ForMember(i => i.DamageDice, opt => opt.MapFrom(source => source.DamageDice))
            .ForMember(i => i.Modifier, opt => opt.MapFrom(source => source.Modifier))
            .ForMember(i => i.Recoil, opt => opt.MapFrom(source => source.Recoil))
            .ForMember(i => i.RateOfFire, opt => opt.MapFrom(source => source.RateOfFire))
            .ForMember(i => i.Shots, opt => opt.MapFrom(source => source.Shots))
            .ForMember(i => i.ArmorDivisor, opt => opt.MapFrom(source => source.ArmorDivisor))
            .ForMember(i => i.Range, opt => opt.MapFrom(source => source.Range))
            .ReverseMap();

        CreateMap<Skill, PostSkillDTO>()
            .ForMember(s => s.Name, opt => opt.MapFrom(source => source.Name))
            .ForMember(s => s.Description, opt => opt.MapFrom(source => source.Description))
            .ForMember(s => s.BaseAttribute, opt => opt.MapFrom(source => source.BaseAttribute))
            .ForMember(s => s.Level, opt => opt.MapFrom(source => source.Level))
            .ReverseMap();

        CreateMap<CustomRoll, PostCustomRollDTO>().ReverseMap();
    }
}