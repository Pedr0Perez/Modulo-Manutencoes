import { IOpcaoSidebar } from "./interface/IOpcaoSidebar";

const opcoesSidebar: Array<IOpcaoSidebar> = [
  {
    id: 0,
    href: "/home",
    title: "Página Inicial",
    items: null,
  },
  {
    id: 3,
    href: null,
    title: "Cadastro",
    items: [
      {
        id: 4,
        href: "/cadastro/dispositivo",
        title: "Dispositivo",
        items: null,
      },
      {
        id: 4,
        href: "/cadastro/tipodispositivo",
        title: "Tipo Dispositivo",
        items: null,
      },
      {
        id: 5,
        href: "/cadastro/memoriaram",
        title: "Tipo Memória RAM",
        items: null,
      },
      {
        id: 5,
        href: "/cadastro/memoriavram",
        title: "Tipo Memória VRAM",
        items: null,
      },
    ],
  },
  {
    id: 1,
    href: null,
    title: "Gerenciamento",
    items: [
      {
        id: 2,
        href: "/gerenciamento/usuarios",
        title: "Usuários",
        items: null,
      },
      {
        id: 1007,
        href: null,
        title: "Teste",
        items: [
          {
            id: 1008,
            href: "/teste",
            title: "teste",
            items: null,
          },
        ],
      },
    ],
  },
];

export default opcoesSidebar;
