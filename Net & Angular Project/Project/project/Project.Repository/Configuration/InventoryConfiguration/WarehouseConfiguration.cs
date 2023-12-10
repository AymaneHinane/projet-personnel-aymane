



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;


namespace Project.Repository.Configuration;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.HasKey(x=>x.Id);

        builder.Property(x=>x.WarehouseType).HasConversion(
            v=>v.ToString(),
            v=>(WarehouseType)Enum.Parse(typeof(WarehouseType),v)
        );

        builder.Property(x=>x.WarehouseRegion).HasConversion(
            v=>v.ToString(),
            v=>(WarehouseRegion)Enum.Parse(typeof(WarehouseRegion),v!)
        );

        

        builder.HasData(

            new Warehouse(){Id=new Guid("148dbd99-602a-4803-8a0a-ee6c8fa3e6ca"),Name="COSUMAR SIDI BENNOUR",WarehouseType=WarehouseType.site},
            new Warehouse(){Id=new Guid("84eb157b-383f-485c-a642-6251441e6d33"),Name="SUTA",WarehouseType=WarehouseType.site},
            new Warehouse(){Id=new Guid("963a84c6-85dd-4f5d-bb5a-b1c2e7d92970"),Name="SUNABEL",WarehouseType=WarehouseType.site},
            new Warehouse(){Id=new Guid("c2bd6e27-8994-4156-b470-750a4b6dd467"),Name="COSUMAR ZAIO",WarehouseType=WarehouseType.site},
            new Warehouse(){Id=new Guid("a948ea36-9fe5-43f2-bc7e-027f6c67f0cd"),Name="SURAC",WarehouseType=WarehouseType.site},
            


            new Warehouse(){Id=new Guid("9aaeffba-e7f3-4480-be43-e06ed561aa60"),Name="212",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("0f1f8d94-fd2e-4a11-97da-06317c69bf62"),Name="221",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("f84c3923-7736-4a13-a81a-7f04d400bdce"),Name="223",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("c78df6d0-2bad-44ec-9c4b-db13f9a0fe9d"),Name="225",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("3edcf2ba-de09-4622-9459-ca43977cd4cd"),Name="231",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("4ecd556d-7245-478c-8cf3-3dc854541a37"),Name="233",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("32ae3428-d477-46df-9ab6-c7bf8b2b5659"),Name="235",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("fd582356-a378-4724-9a2c-439f15775471"),Name="2202",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("da46877b-8f17-4cb5-b696-ab249f110b55"),Name="211-222",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("6f5581cb-b7d8-499c-96ce-332f0f7a58b9"),Name="214-246-217",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("1b4fd25c-1252-441f-bb43-b0262392e2e0"),Name="246-247",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("f64f1686-6393-4744-abf0-160ec12b51ce"),Name="224-226",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("d985408b-f99c-4b3f-a833-b39a90ceff75"),Name="218-241",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("1218f634-58ee-4625-a678-0215723779f3"),Name="234-242",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("9a2d100e-aaf8-4643-8fc2-c845e57b051d"),Name="236-237",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("701d8c10-1705-44f8-b214-2be19bffbb2c"),Name="213",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("55b085af-3dc2-4e54-b1e2-0920cd625057"),Name="243-943",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("5c68463e-0a95-4aee-85b3-baa8e989d7d5"),Name="244-245",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("84e3e39d-71d6-40d3-9b42-3d48cf5843e7"),Name="901",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("9da3395d-e98b-4a4c-8541-24138f872c0c"),Name="906",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("6e1ca860-6cab-46cd-9e1d-0e29a6948505"),Name="909",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_GHARB},
            new Warehouse(){Id=new Guid("39c12cc8-e7e9-4c55-9ef1-a8bdac6f9040"),Name="901",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_LOUKKOS},
            new Warehouse(){Id=new Guid("e47f1a3d-65bc-4c6c-889c-0f9ffc1d26cb"),Name="906",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_LOUKKOS},
            new Warehouse(){Id=new Guid("9487367e-9956-4923-8f69-5487753ad4be"),Name="909",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUNABEL_LOUKKOS},



            new Warehouse(){Id=new Guid("54249fa6-9bbf-47b9-9a74-f297d8849e53"),Name="221",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("ccc33ad3-4e61-42c8-b4a4-bd9a27d46738"),Name="223",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("310b0a03-431b-4bfd-a794-a36fe0cc2850"),Name="225",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("6fa3b325-8509-4a93-874f-89f2d97661a0"),Name="231",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("6894b368-3f2a-441f-ba05-82a27e12655b"),Name="233",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("288e8aa3-2c91-4b19-9d8e-0959ab39e112"),Name="235",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("1199cf49-b675-4367-9b85-ed6ddeedbb48"),Name="211-222",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("8d87e8d7-a7f6-4946-9344-3c9c09e0b02a"),Name="217",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("677d7486-6459-4d75-b2b0-6e22d5f3a9b7"),Name="246-247",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("8c1a76c8-067c-40fc-bbf2-2ded5d95deb3"),Name="224-226",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("05c2b649-4b87-413e-a02a-6e82a12a1b34"),Name="218-241",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("beef3e5d-d8a1-427a-9cdc-ab9696abf449"),Name="234-242",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("51b6d8f3-4c35-4564-aa4c-d7cea1b5758a"),Name="236-237",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("b6520c8f-246c-4034-b6ac-979a59ad534f"),Name="243-943",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},
            new Warehouse(){Id=new Guid("4df39384-729c-4f58-b6e0-b736cf171900"),Name="244-245",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_GHARB},

            new Warehouse(){Id=new Guid("7f39e309-ad64-4fbc-9b8c-b4fbbf960cd4"),Name="901-909",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_CANNE},
            new Warehouse(){Id=new Guid("c0c4b904-e97b-483a-8b4c-ddef5ebd0486"),Name="903",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_CANNE},
            new Warehouse(){Id=new Guid("b626eba3-1ba2-430c-a794-12ab302ce222"),Name="906",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SURAC_CANNE},



            new Warehouse(){Id=new Guid("35007bcc-dbc9-40c7-aa61-155853631e4d"),Name="501/502/511",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("5162df2c-3ecc-4a1f-82be-11a15408230e"),Name="503",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("955469f8-c4b0-4efc-af93-4f3fc999f04c"),Name="504",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("701145ec-a1b1-4d0c-8438-8467dff0987d"),Name="505/510/512",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("60aaa4f3-a55b-4d77-b50a-2afc75f35cf9"),Name="506",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("bc56e4bd-c0b1-4f6e-ab62-f8459dd4d09d"),Name="507",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("c561527f-437c-4f7c-a388-285d782e71ee"),Name="508",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("b51028cb-0ca2-4141-9618-b07145481abc"),Name="509",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("ec417426-2c4b-43da-8227-7bbebe9c49b3"),Name="520",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("2b25c366-c63c-4fc7-a257-84d8f2771b0b"),Name="521",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("8ed5c72c-f600-4db3-9cd0-00f729a8601f"),Name="522",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("b7e6df3f-aab2-4b2b-b119-ce1bb7665511"),Name="524",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("bde361c5-3ba7-4319-a766-0748dbef1232"),Name="525",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("8bfd1680-4a5e-4cb0-8054-528f791e50a2"),Name="526",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("7210ab96-8812-49be-bc27-60e554b329c0"),Name="527",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("ed9c654f-4087-4611-add4-0c9aeb42c377"),Name="528",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("f55e5b0d-83b8-4402-9433-2237ba3bba41"),Name="529",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("54be1ecc-597f-4551-9fd6-7831b29790f7"),Name="530",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("b96d9aad-1169-4030-a919-d7abaea5357e"),Name="531",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("b54a1052-7140-4b36-a2e3-8788a97590ea"),Name="532",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("05d1b779-e3b8-47cd-b993-8f1f6f05da7a"),Name="533",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("ff2204b9-3ea8-4161-975f-e8833465a710"),Name="534-538",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("f10d7f01-0851-4c16-8af3-f1019b1286bf"),Name="535",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("315f3187-ffbe-4bab-bdd8-38c9ea774adf"),Name="536",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("d617507d-f7f5-4f07-83c8-c4a51637595c"),Name="537",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("c966fabf-410b-4e8e-b36f-ba1c7f67723e"),Name="1104/1-2-3",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("80abbdd2-0f9e-48dc-8b6e-f29a3770d45b"),Name="1104/4-7",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("50f266f8-d795-4760-9c0c-c05eb79ac8d0"),Name="1104/5-8",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("36521355-e9b7-44b3-9291-99ac13c72176"),Name="1104/6",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("686a6256-1fdb-4350-a402-3882cd347a96"),Name="1104/9",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("791c5147-415c-4c60-b81f-6bf5e82cfde2"),Name="1107",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("30b351e9-4472-438c-aa17-36e6a239c9c8"),Name="404",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("fbae2eaa-fe0a-4404-8db9-71c3ed94ab71"),Name="2404",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},
            new Warehouse(){Id=new Guid("18ada911-3a67-4666-a14d-27bcd96d1e40"),Name="1504",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SUTA},


            new Warehouse(){Id=new Guid("49f628cd-1fef-4f92-a25c-f56ecc7ed1a0"),Name="PhytoBerkane",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.ZAIO},
            new Warehouse(){Id=new Guid("cc730cda-69b5-42b6-8e6d-518c50668e66"),Name="Etablissement CHICKRI",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.ZAIO},
            new Warehouse(){Id=new Guid("fe93782b-e08f-40b7-9eed-331e5e418f60"),Name="Bouyahyie FELLAH",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.ZAIO},
            new Warehouse(){Id=new Guid("5b32fa0c-e7d6-4dc9-8d2f-ddedd3c3ebdf"),Name="AGROSSAR",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.ZAIO},


        
            new Warehouse(){Id=new Guid("2f4173fa-b41f-4309-8a17-81285023ca41"),Name="310",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("ff1fb08f-158d-4b1d-8346-a39e8841124b"),Name="311",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("1cf5a15d-5bb3-490c-a212-45ceeec22365"),Name="312",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("da1921c3-d6da-478f-b4c8-94c9c003e48b"),Name="332",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("26b0d281-dd5c-47f9-ae05-2da0cd219a94"),Name="351",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("c31d7f27-3806-4a1b-9892-4d31666b93f6"),Name="352",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("c2a195e7-7f53-4be5-a3e3-3e64c9735837"),Name="330",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("bb6de288-3620-4ffb-8b37-ad35f0d9d095"),Name="331",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("bf41a037-d9fb-4ac7-ba88-e618747e7765"),Name="333",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("a004cf49-4772-4c08-90b3-cf6915e18053"),Name="335",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("12000c54-09d6-43f3-9505-5c2155099a39"),Name="336",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("c8f69301-e79a-4a0a-9ae2-233195f1239f"),Name="337",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("7da6e83e-06df-4156-a84c-295ad73b686d"),Name="338",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("cf051303-6ae5-48cc-bcf8-cdb2e82c6812"),Name="353",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("9195edf5-7605-422f-8bb0-9ab4b729294c"),Name="354",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("14a4c70a-6a82-4d1e-902f-b2d9bd9f5373"),Name="360",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("72f9a741-d736-4040-88c1-6b3333c9124c"),Name="361",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("b97408c1-cb48-44f3-8506-94103ece669f"),Name="362",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("e7a807df-2627-41f9-a15b-8fc84a994526"),Name="320",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("430e7f1d-600d-4843-82d0-837066dd677b"),Name="321",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("3f14a919-d7fa-4cb2-95d2-dcfb14a13694"),Name="322",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("41562eaa-735d-4ce9-9b42-cdd6c44bc7f1"),Name="324",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("992c0dfa-cc81-4f82-93b9-e846c1b52c10"),Name="325",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("6b48d6d2-c40c-45da-92ce-e88b020206b9"),Name="340",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("48513294-21c9-4bab-925d-1eb3a7c1a1de"),Name="341",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("7bf334ec-9229-4ae5-ac76-faa5e661fabb"),Name="342",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("83efd78e-174f-4d57-9ed0-28549c502cc7"),Name="343",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("7811ac4b-1262-4a52-82ac-fb7735714d97"),Name="363",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR},
            new Warehouse(){Id=new Guid("7ab89f0a-16f8-4eef-9957-2bc63508c658"),Name="400",WarehouseType=WarehouseType.distributionCenter,WarehouseRegion=WarehouseRegion.SIDI_BENNOUR}



            );

    }
}