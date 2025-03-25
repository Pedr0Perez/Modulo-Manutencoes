import { createContext, ReactNode, useContext, useState } from "react";
import { SidebarAberturaEnum } from "../enums/SidebarAberturaEnum";
import { IControleAberturaSidebar } from "./interface/IControleAberturaSidebar";

export const ControleAberturaSidebarContext = createContext<
  IControleAberturaSidebar | undefined
>(undefined);

export const ControleAberturaSidebarProvider = ({
  children,
}: {
  children: ReactNode;
}) => {
  const [controleSidebar, setControleSidebar] = useState<SidebarAberturaEnum>(
    SidebarAberturaEnum.Exibir
  );

  return (
    <ControleAberturaSidebarContext.Provider
      value={{ controleSidebar, setControleSidebar }}
    >
      {children}
    </ControleAberturaSidebarContext.Provider>
  );
};

export const useControleAberturaSidebar = (): IControleAberturaSidebar => {
  const context = useContext(ControleAberturaSidebarContext);
  if (!context)
    throw new Error(
      "useControleAberturaSidebar deve ser usado dentro de um ControleAberturaSidebarProvider"
    );

  return context;
};
