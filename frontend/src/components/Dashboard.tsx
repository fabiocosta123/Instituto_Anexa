// src/pages/dashboard.tsx
import Sidebar from './Sidebar'
import Header from './Header'
import '../styles/dashboard.css'

export default function Dashboard() {
  return (
    <div className="dashboard-container">
      <Sidebar />
      <div className="main-content">
        <Header />
        <main className="dashboard-main">
          <h2>Dashboard em construção...</h2>
        </main>
      </div>
    </div>
  )
}
