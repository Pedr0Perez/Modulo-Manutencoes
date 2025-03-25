import { JSX } from "@emotion/react/jsx-runtime";
import DefaultLayout from "../DefaultLayout";
import { ControleAberturaSidebarProvider } from "../../../contexts/ControleAberturaSidebarContext";

const DefaultPage = (): JSX.Element => {
  return (
    <>
      <ControleAberturaSidebarProvider>
        <DefaultLayout />
      </ControleAberturaSidebarProvider>
    </>
  );
};

export default DefaultPage;
