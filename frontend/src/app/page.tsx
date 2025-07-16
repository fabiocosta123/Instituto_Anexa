'use client';

import Image from 'next/image';
import { useRouter } from 'next/navigation';

export default function HomePage() {
  const router = useRouter();

  return (
    <main className='min-h-screen flex flex-col items-center justify-center bg-gradient-to-b from-indigo-50 to-white px-4'>
      <div className='max-w-4xl text center'>
        <Image 
          src='/cursodeteologia.jpg'
          alt='Curso de Teologia'
          width={600}
          height={400}
          className='mx-auto rounded shadow-lg'
        />
        
        <h1 className='text-4xl font-bold mt-6 mb-4 text-indigo-900'>Descubra o poder do conhecimento teológico</h1>

        <p className="text-lg text-gray-700 mb-6">
          Estude as Escrituras, fortaleça sua fé e capacite-se para servir com profundidade e propósito. Uma jornada espiritual e acadêmica como nenhuma outra.
        </p>

        <button
          onClick={() => router.push('/registro')}
          className="bg-indigo-600 text-white px-6 py-3 rounded hover:bg-indigo-700 transition-all cursor-pointer font-medium"
        >
          Matricular-se
        </button>

      </div>
    </main>
  );
}