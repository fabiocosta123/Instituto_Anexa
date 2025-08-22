// src/components/Sidebar.tsx
import '../styles/sidebar.css'

export default function Sidebar() {
  return (
    <aside className="sidebar">
      <div className="logo">Anexa</div>
      <nav className="nav">
        <a href="#" className="nav-item active">Home</a>
        <a href="#">Courses</a>
        <a href="#">Grades</a>
        <a href="#">Profile</a>
        <a href="#">Settings</a>
      </nav>
    </aside>
  )
}
