'use client';

import './quem-somos.css';

const pastores = [
  {
    nome: 'Pr. Felipe Lopes',
    formacao: 'Bacharel em Teologia',
    igreja: 'AD Belém - Itanhaém',
    foto: './prFelipe.png',
  },
  {
    nome: 'Pr. Reuel Padilha',
    formacao: 'Bacharelado em Teologia',
    igreja: 'AD Belém - Sede',
    foto: '/pastor2.jpg',
  },
  {
    nome: 'Pr. Abraão Ramalho',
    formacao: 'Bacharel em Teologia',
    igreja: 'AD Belém - Sede',
    foto: '/pastor3.jpg',
  },
];

export default function QuemSomosPage() {
  return (
    <div className="qs-container">
      <h1 className="qs-title">Quem Somos</h1>
      <p className="qs-text">
        Somos a <strong>Assembleia de Deus Ministério Belém – Campo de Registro</strong>, uma igreja centenária, conservadora e comprometida com os princípios bíblicos. Nosso campo conta com mais de <strong>150 igrejas</strong> espalhadas pelo Vale do Ribeira, levando a Palavra de Deus com seriedade, amor e dedicação.
      </p>

      <h2 className="qs-subtitle">Nossos Pastores</h2>
      <div className="qs-grid">
        {pastores.map((p, index) => (
          <div key={index} className="qs-card">
            <img src={p.foto} alt={p.nome} className="qs-foto" />
            <h3>{p.nome}</h3>
            <p>{p.formacao}</p>
            <p><em>{p.igreja}</em></p>
          </div>
        ))}
      </div>
    </div>
  );
}
