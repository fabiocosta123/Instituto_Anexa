import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import Link from "next/link";
import { FaLinkedin, FaGithub } from "react-icons/fa";
import "./globals.css";
import ThemeToggle from "@/components/ThemeToogle";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata: Metadata = {
  title: "Anexa",
  description: "Sistema de cursos desenvolvido por Fábio Costa",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="pt-BR">
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased`}
      >
        <div className="layout-wrapper">
          <ThemeToggle />

          <nav className="layout-nav">
            <div className="layout-logo">Anexa</div>
            <ul className="layout-menu">
              <li>
                <Link href="/">Início</Link>
              </li>
              <li>
                <Link href="/cursos">Cursos</Link>
              </li>
              <li>
                <Link href="/quem-somos">Quem Somos</Link>
              </li>
              <li>
                <Link href="/login">Login</Link>
              </li>
            </ul>
          </nav>

          <main className="layout-content">{children}</main>

          <footer className="layout-footer">
            <span>© Desenvolvido por Fábio Costa</span>
            <div className="layout-social">
              <a
                href="https://www.linkedin.com/in/fabio-costa-silva-/"
                target="_blank"
                rel="noopener noreferrer"
              >
                <FaLinkedin size={20} />
              </a>
              <a
                href="https://github.com/fabiocosta123/"
                target="_blank"
                rel="noopener noreferrer"
              >
                <FaGithub size={20} />
              </a>
            </div>
          </footer>
        </div>
      </body>
    </html>
  );
}
