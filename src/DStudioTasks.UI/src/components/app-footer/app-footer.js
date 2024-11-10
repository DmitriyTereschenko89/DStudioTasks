import '../app-footer/app-footer.css';
import { Flex } from "@mantine/core";
import Footer from "../ui-components/footer-label";

const AppFooter = () => {
    return (
        <Flex
            justify={'center'}
            align={'center'}
            className='footer'>
            <Footer />
        </Flex>
    );
};

export default AppFooter;
