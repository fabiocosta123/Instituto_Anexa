'use client';
import { useEffect } from "react";
import { useRouter } from "next/navigation";

export default function RedirectToHomePage() {
  const router = useRouter();

  useEffect(() => {
    router.push("/homePage");
  }, [router]);

  return null;
}
