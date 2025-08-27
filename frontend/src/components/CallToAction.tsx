import { useRouter } from "next/navigation";
import { motion } from "framer-motion";
import "../style/callToAction.css";

export default function CallToAction() {
  const router = useRouter();

  return (
    <motion.div
      className="cta-container"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ delay: 0.7, duration: 0.5 }}
    >
      <motion.button
        whileHover={{ scale: 1.05 }}
        whileTap={{ scale: 0.95 }}
        onClick={() => router.push("/register")}
        className="cta-button"
      >
        Matricular-se
      </motion.button>
    </motion.div>
  );
}
