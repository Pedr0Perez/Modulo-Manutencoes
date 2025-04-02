import { IOpcaoSidebar } from "./interface/IOpcaoSidebar";
import HomeOutlinedIcon from "@mui/icons-material/HomeOutlined";
import DeveloperBoardOutlinedIcon from "@mui/icons-material/DeveloperBoardOutlined";
import ComputerOutlinedIcon from "@mui/icons-material/ComputerOutlined";
import PhonelinkOutlinedIcon from "@mui/icons-material/PhonelinkOutlined";
import MemoryOutlinedIcon from "@mui/icons-material/MemoryOutlined";
import SettingsOutlinedIcon from "@mui/icons-material/SettingsOutlined";
import GroupOutlinedIcon from "@mui/icons-material/GroupOutlined";
import AddOutlinedIcon from "@mui/icons-material/AddOutlined";
import FormatListBulletedOutlinedIcon from "@mui/icons-material/FormatListBulletedOutlined";

const opcoesSidebar: Array<IOpcaoSidebar> = [
  {
    id: 0,
    href: "/home",
    title: "Página Inicial",
    icon: <HomeOutlinedIcon />,
    items: null,
  },
  {
    id: 4,
    href: null,
    title: "Dispositivo",
    icon: <ComputerOutlinedIcon />,
    items: [
      {
        id: 512,
        href: "/dispositivo/cadastro",
        title: "Cadastro",
        icon: <AddOutlinedIcon />,
        items: null,
      },
      {
        id: 214,
        href: "/dispositivo/listagem",
        title: "Listagem",
        icon: <FormatListBulletedOutlinedIcon />,
        items: null,
      },
    ],
  },
  {
    id: 3,
    title: "Tipos Hardware",
    icon: <DeveloperBoardOutlinedIcon />,
    items: [
      {
        id: 5,
        title: "Tipo Dispositivo",
        icon: <PhonelinkOutlinedIcon />,
        items: [
          {
            id: 512,
            href: "/tiposhardware/tipodispositivo/cadastro",
            title: "Cadastro",
            icon: <AddOutlinedIcon />,
            items: null,
          },
          {
            id: 214,
            href: "/tiposhardware/tipodispositivo/listagem",
            title: "Listagem",
            icon: <FormatListBulletedOutlinedIcon />,
            items: null,
          },
        ],
      },
      {
        id: 6,
        title: "Tipo Memória RAM",
        icon: <MemoryOutlinedIcon />,
        items: [
          {
            id: 512,
            href: "/tiposhardware/ram/cadastro",
            title: "Cadastro",
            icon: <AddOutlinedIcon />,
            items: null,
          },
          {
            id: 214,
            href: "/tiposhardware/ram/listagem",
            title: "Listagem",
            icon: <FormatListBulletedOutlinedIcon />,
            items: null,
          },
        ],
      },
      {
        id: 7,
        title: "Tipo Memória VRAM",
        icon: <MemoryOutlinedIcon />,
        items: [
          {
            id: 512,
            href: "/tiposhardware/vram/cadastro",
            title: "Cadastro",
            icon: <AddOutlinedIcon />,
            items: null,
          },
          {
            id: 214,
            href: "/tiposhardware/vram/listagem",
            title: "Listagem",
            icon: <FormatListBulletedOutlinedIcon />,
            items: null,
          },
        ],
      },
    ],
  },
  {
    id: 1,
    href: null,
    title: "Gerenciamento",
    icon: <SettingsOutlinedIcon />,
    items: [
      {
        id: 2,
        href: "/gerenciamento/usuarios",
        title: "Usuários",
        icon: <GroupOutlinedIcon />,
        items: null,
      },
    ],
  },
];

export default opcoesSidebar;
