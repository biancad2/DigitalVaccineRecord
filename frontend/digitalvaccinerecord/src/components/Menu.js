import React, { useState } from 'react';
import {
    Collapse,
    Navbar,
    NavbarToggler,
    NavbarBrand,
    Nav,
    NavItem,
    NavLink,
    UncontrolledDropdown,
    DropdownToggle,
    DropdownMenu,
    DropdownItem,
    NavbarText,
} from 'reactstrap';

function Menu(args) {
    const [isOpen, setIsOpen] = useState(false);

    const toggle = () => setIsOpen(!isOpen);

    return (
        <Navbar fixed={"top"} container={"fluid"} expand={"md"} color={"light"}>
            <NavbarBrand href="/">Carteira de Vacinação</NavbarBrand>
            <NavbarToggler onClick={toggle} />
            <Collapse isOpen={isOpen} navbar>
                <Nav className="me-auto" navbar>
                    <UncontrolledDropdown nav inNavbar>
                        <DropdownToggle nav caret>
                            Usuários
                        </DropdownToggle>
                        <DropdownMenu end>
                            <DropdownItem href='/users'>Listar</DropdownItem>
                            <DropdownItem href='/users/register'>Adicionar</DropdownItem>
                        </DropdownMenu>
                    </UncontrolledDropdown>
                    <UncontrolledDropdown nav inNavbar>
                        <DropdownToggle nav caret>
                            Vacinas
                        </DropdownToggle>
                        <DropdownMenu end>
                            <DropdownItem href='/vaccines'>Listar</DropdownItem>
                            <DropdownItem href='/vaccines/register'>Adicionar</DropdownItem>
                        </DropdownMenu>
                    </UncontrolledDropdown>
                </Nav>
            </Collapse>
        </Navbar>
    );
}

export default Menu;