import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../index.css';

function LoginPage() {
  const navigate = useNavigate();
  const [loginId, setLoginId] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();

    // TODO: 나중에 여기서 실제 로그인 API 호출하고 검증
    // 일단은 로그인 성공했다고 치고 대시보드로 보냄
    navigate('/dashboard');
  };

  return (
    <div className="app-root">
      <div className="space-layer" />
      <div className="stars-layer" />

      <div className="login-page">
        <div className="login-card">
          <div className="login-header">
            <div className="logo-orbit">
              <div className="logo-planet" />
              <div className="logo-ring" />
            </div>
            <h1 className="login-title">왹져 상담센터</h1>
            {/* <p className="login-subtitle">
              은하계 상담 센터 콘솔에 접속하세요.
            </p> */}
          </div>

          <form className="login-form" onSubmit={handleSubmit}>
            <div className="form-group">
              <label htmlFor="loginId">Agent number</label>
              <input
                id="loginId"
                type="text"
                placeholder="earth-agent001"
                autoComplete="username"
                value={loginId}
                onChange={(e) => setLoginId(e.target.value)}
              />
            </div>

            <div className="form-group">
              <label htmlFor="password">Password</label>
              <input
                id="password"
                type="password"
                placeholder="●●●●●●●●"
                autoComplete="current-password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>

            <div className="login-options">
              <label className="remember-me">
                <input type="checkbox" />
                <span>Remember ID</span>
              </label>

              <button
                type="button"
                className="text-button"
              >
                Forget password?
              </button>
            </div>

            <button type="submit" className="login-button">
              Entering Orbit
            </button>
          </form>

          <div className="login-footer">
            <p>ⓒ {new Date().getFullYear()} CounselFlow · Galaxy Ops</p>
            <p className="login-footer-hint">
              This area is accessible only to authorized in-house agents.
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default LoginPage;
