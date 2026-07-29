
using System.Collections.Generic;

namespace Study.MiniDefence
{
    public class UnitTable
    {
        private const string TableName = "MiniDefence/units";
        
        private Dictionary<int, UnitDef> unitDefs = new();

        public int Count => unitDefs.Count;
        
        // 현재 테이블에 등록된 모든 Values(Unit들)을 읽기전용 콜렉션 형태로 리턴한다
        // 외부에서 foreach같은걸로 조회할수 있다
        public IReadOnlyCollection<UnitDef> Units => unitDefs.Values;
        public UnitDef Get(int id) => unitDefs[id];
        
        public void Load()
        {
            unitDefs.Clear();
            // DTO 읽고, Def로 바꿔서 저장해준다
            
            List<UnitDTO> rows = TSVReader
        }
    }
}