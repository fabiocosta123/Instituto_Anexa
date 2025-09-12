// src/services/api.ts
const baseUrl = process.env.API_URL;

export default async function request(path: string, opts: RequestInit = {}) {
  const res = await fetch(`${baseUrl}${path}`, {
    headers: { 'Content-Type': 'application/json' },
    ...opts,
  });
  if (!res.ok) throw new Error(await res.text());
  return res.json();
}