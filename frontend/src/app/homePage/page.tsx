"use client"

import HeroSection from '@/components/HeroSection';
import CallToAction from '@/components/CallToAction';
import '@/style/callToAction.css';
import ThemeToggle from '@/components/ThemeToogle';

export default function HomePage() {
  return (
    <main className="home">
      <div className="home-content">       
        <HeroSection />
        <CallToAction />
      </div>
    </main>
  );
}
