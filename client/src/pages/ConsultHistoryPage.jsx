const MOCK_CONSULTS = [
  {
    id: 'C-202512-001',
    title: '데이터 속도 저하 문의',
    keyword: '데이터 / 속도',
    status: '진행중',
    agent: '김상담',
    customer: '홍길동',
    createdAt: '2025-12-04 10:41',
  },
  {
    id: 'C-202512-002',
    title: '요금 할인 미적용 문의',
    keyword: '요금 / 할인',
    status: '종료',
    agent: '이상담',
    customer: '이고객',
    createdAt: '2025-12-03 15:20',
  },
  {
    id: 'C-202512-003',
    title: '5G -> LTE 요금제 변경',
    keyword: '요금제 / 변경',
    status: '대기',
    agent: '박상담',
    customer: '최고객',
    createdAt: '2025-12-02 09:12',
  },
];

function ConsultHistoryPage() {
  // 나중에 여기에 검색 상태/이벤트 추가하면 됨
  return (
    <div className="consult-history-root">
      {/* 헤더 영역 */}
      <div className="consult-history-header">
        <h2 className="consult-history-title">상담기록</h2>
        {/* <p className="consult-history-subtitle">
          제목, 키워드, 상태 기준으로 상담 이력을 조회합니다.
        </p> */}
      </div>

      {/* 리스트 영역 */}
      <div className="consult-history-table">
        {/* 헤더 행 */}
        <div className="consult-history-row consult-history-row-head">
          <span>제목</span>
          <span>키워드</span>
          <span>상태</span>
          <span>상담사</span>
          <span>고객</span>
          <span>생성일</span>
        </div>

        {/* 데이터 행 */}
        {MOCK_CONSULTS.map((c) => (
          <div key={c.id} className="consult-history-row consult-history-row-body">
            <span className="ch-cell-title">{c.title}</span>
            <span>{c.keyword}</span>
            <span>{c.status}</span>
            <span>{c.agent}</span>
            <span>{c.customer}</span>
            <span>{c.createdAt}</span>
          </div>
        ))}

        {/* 데이터 없을 때용 – 나중에 조건식으로 쓰면 됨 */}
        {MOCK_CONSULTS.length === 0 && (
          <div className="consult-history-empty">
            조회된 상담 기록이 없습니다.
          </div>
        )}
      </div>

      {/* 검색 영역 */}
      <div className="consult-history-search">
        <label className="ch-search-label">검색 기준</label>
        <select className="ch-search-select" defaultValue="title">
          <option value="title">제목</option>
          <option value="keyword">키워드</option>
          <option value="status">상태</option>
        </select>

        <input
          className="ch-search-input"
          type="text"
          placeholder="검색어를 입력하세요."
        />

        <button type="button" className="ch-search-button">
          검색
        </button>
      </div>
    </div>
  );
}

export default ConsultHistoryPage;
