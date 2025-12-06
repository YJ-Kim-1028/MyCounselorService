import { useState } from 'react';
import ConsultHistoryPage from './ConsultHistoryPage';

function Dashboard() {
  // 기본 탭: 상담기록
  const [activeTab, setActiveTab] = useState('history');

  const renderContent = () => {
    switch (activeTab) {
      case 'history':
        return <ConsultHistoryPage />;

      case 'write':
        return (
          <div style={{ padding: '16px' }}>
            <h2 style={{ fontSize: '18px', margin: '0 0 12px' }}>상담작성</h2>
            <p style={{ fontSize: '13px', opacity: 0.8 }}>
              여기에는 나중에 새 상담 작성 폼이 들어갈 예정입니다.
            </p>
          </div>
        );

      case 'mypage':
        return (
          <div style={{ padding: '16px' }}>
            <h2 style={{ fontSize: '18px', margin: '0 0 12px' }}>MyPage</h2>
            <p style={{ fontSize: '13px', opacity: 0.8 }}>
              상담사 프로필, 오늘 처리 건수, 공지사항 등을 여기에 배치할 수 있습니다.
            </p>
          </div>
        );

      default:
        return null;
    }
  };

  return (
    <div className="app-root">
      <div className="space-layer" />
      <div className="stars-layer" />

            <div className="dashboard-page">
        <div className="dashboard-shell">

          {/* 상단 헤더 – 로고 중앙, 그 밑에 탭 */}
          <header className="dashboard-topbar">
            <div className="dashboard-brand dashboard-brand-center">
              <div className="brand-logo-orbit brand-logo-big">
                <div className="brand-logo-core" />
              </div>
              <div className="brand-text">
                <span className="brand-name brand-name-big">왹져상담센터</span>
                {/* <span className="brand-sub">CounselFlow Console</span> */}
              </div>
            </div>

            <nav className="dashboard-menu dashboard-menu-center">
              <button
                type="button"
                className={`nav-chip ${activeTab === 'history' ? 'nav-chip-active' : ''}`}
                onClick={() => setActiveTab('history')}
              >
                상담기록
              </button>

              <button
                type="button"
                className={`nav-chip ${activeTab === 'write' ? 'nav-chip-active' : ''}`}
                onClick={() => setActiveTab('write')}
              >
                상담작성
              </button>

              <button
                type="button"
                className={`nav-chip ${activeTab === 'mypage' ? 'nav-chip-active' : ''}`}
                onClick={() => setActiveTab('mypage')}
              >
                MyPage
              </button>
            </nav>
          </header>

          {/* 중앙 컨텐츠 박스 – 탭에 따라 내용만 바뀜 */}
          <main className="dashboard-main">
            <div
              className="dashboard-body-panel"
            >
              {renderContent()}
            </div>
          </main>

          <footer className="site-footer">
            <p>ⓒ {new Date().getFullYear()} 왹져상담센터</p>
            <p>내부 상담 운영 시스템 · 무단 사용 및 접근 금지</p>
          </footer>
        </div>
      </div>
    </div>
  );
}

export default Dashboard;
