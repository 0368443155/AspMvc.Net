using CS68_MVC01.Models;

namespace CS68_MVC01.Services
{
	public class PlanetService : List<PlanetModel>
	{
		public PlanetService()
		{
			Add(new PlanetModel()
			{
				Id = 1,
				Name = "Mecury",
				VnName = "Sao Thủy",
				Content = "Là hành tinh nhỏ nhất và gần Mặt Trời nhất."
			});
			Add(new PlanetModel()
			{
				Id = 2,
				Name = "Venus",
				VnName = "Sao Kim",
				Content = "Hay gọi là sao Mai."
			});
			Add(new PlanetModel()
			{
				Id = 3,
				Name = "Earth",
				VnName = "Trái Đất",
				Content = "Vị trí thứ 3. Hành tinh duy nhất có sự sống."
			});
			Add(new PlanetModel()
			{
				Id = 4,
				Name = "Mars",
				VnName = "Sao Hỏa",
				Content = "Hành tinh thứ tư. Được coi là ngôi nhà thứ 2 của loài người trong tương lai."
			});
			Add(new PlanetModel()
			{
				Id = 5,
				Name = "Jupiter",
				VnName = "Sao Mộc",
				Content = "Hành tinh lớn nhất tỏng hệ mặt trời. Là một hành tinh khí khổng lồ."
			});
			Add(new PlanetModel()
			{
				Id = 6,
				Name = "Saturn",
				VnName = "Sao Thổ",
				Content = "Là hành tinh duy nhất có nhẫn hành tinh"
			});
			Add(new PlanetModel()
			{
				Id = 7,
				Name = "Uranus",
				VnName = "Sao Thiên Vương",
				Content = "Hành tinh băng khổng lồ"
			});
			Add(new PlanetModel()
			{
				Id = 8,
				Name = "Neptune",
				VnName = "Sao Hải Vương",
				Content = "Lớn thứ tư về đường kính và lớn thứ 3 về khối lượng"
			});
		}
	}
}
