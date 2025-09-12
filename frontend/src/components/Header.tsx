import '../styles/header.css'
import Image from 'next/image'

export default function Header() {
  return (
    <header className="header">
      <h1>Welcome back, Fábio</h1>
      <Image src="/user.jpg" alt="User" className="user-photo" />
    </header>
  )
}
