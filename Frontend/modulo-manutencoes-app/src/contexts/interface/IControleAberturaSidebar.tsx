import { SidebarAberturaEnum } from "../../enums/SidebarAberturaEnum";

export interface IControleAberturaSidebar {
  controleSidebar: SidebarAberturaEnum;
  setControleSidebar: React.Dispatch<React.SetStateAction<SidebarAberturaEnum>>;
}
