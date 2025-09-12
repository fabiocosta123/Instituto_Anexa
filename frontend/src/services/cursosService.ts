import request from './api';
import { Curso } from '../types/curso';

export function getCursos(): Promise<Curso[]> {
  return request('/api/cursos');
}