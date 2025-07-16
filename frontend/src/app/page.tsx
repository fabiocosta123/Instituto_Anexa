'use client';

import { useRouter } from 'next/navigation';

export default function HomePage() {
  const router = useRouter();

  return (
    <main className="flex flex-col items-center justify-center min-h-screen bg-blue-50">
      <h1 className="text-3xl font-bold mb-6">Bem-vindo à Plataforma Anexa</h1>
      <button
        onClick={() => router.push('/login')}
        className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 cursor-pointer transition-colors"
      >
        Entrar
      </button>
    </main>
  );
}