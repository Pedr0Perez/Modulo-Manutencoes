type sessionType = {
  nome: string;
  email: string;
  email2: string | null;
  aniversario: string | null;
  genero: string;
  pais: string | null;
  cidade: string | null;
  estado: string | null;
  admin: boolean;
  superAdmin: boolean;
};

export default sessionType;
