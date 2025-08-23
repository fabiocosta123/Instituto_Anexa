'use client';

import { useEffect, useState } from "react";
import "@/style/theme.css";

export default function ThemeToggle() {
  const [theme, setTheme] = useState("light");

  useEffect(() => {
    document.documentElement.setAttribute("data-theme", theme);
  }, [theme]);

  const toggleTheme = () => {
    setTheme(prev => (prev === "light" ? "dark" : "light"));
  };

  return (
    <button onClick={toggleTheme} className="theme-toggle">
      {theme === "light" ? "🌙" : "☀️"}
    </button>
  );
}
