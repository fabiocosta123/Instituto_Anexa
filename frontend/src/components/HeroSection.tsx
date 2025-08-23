import Image from "next/image";
import { motion } from "framer-motion";
import "@/style/heroSection.css";

export default function HeroSection() {
  return (
    <motion.section
      className="hero"
      initial={{ opacity: 0, y: 30 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.6 }}
    >
      <motion.div
        initial={{ scale: 0.95 }}
        animate={{ scale: 1 }}
        transition={{ duration: 0.5 }}
      >
        <Image
          src="/cursodeteologia.jpg"
          alt="Curso de Teologia"
          width={600}
          height={400}
          className="hero-image"
        />
      </motion.div>

      <motion.h1
        className="hero-title"
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ delay: 0.3, duration: 0.5 }}
      >
        Descubra o poder do conhecimento teológico
      </motion.h1>

      <motion.p
        className="hero-description"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ delay: 0.5, duration: 0.5 }}
      >
        Estude as Escrituras, fortaleça sua fé e capacite-se para servir com
        profundidade e propósito. Uma jornada espiritual e acadêmica como
        nenhuma outra.
      </motion.p>
    </motion.section>
  );
}
