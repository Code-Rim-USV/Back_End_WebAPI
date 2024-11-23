toc.dat                                                                                             0000600 0004000 0002000 00000027502 14720264421 0014447 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP       !            
    |            examplanner    17.1    17.1 (    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false         �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false         �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false         �           1262    17209    examplanner    DATABASE     �   CREATE DATABASE examplanner WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
    DROP DATABASE examplanner;
                     postgres    false                     2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                     pg_database_owner    false         �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                        pg_database_owner    false    4         �            1259    17213    exams_sq    SEQUENCE     v   CREATE SEQUENCE public.exams_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000000
    CACHE 1;
    DROP SEQUENCE public.exams_sq;
       public               postgres    false    4         �            1259    17214    Exams    TABLE     \  CREATE TABLE public."Exams" (
    "ExamID" integer DEFAULT nextval('public.exams_sq'::regclass) NOT NULL,
    "Group" integer NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "AssistantID" integer,
    "Date" date NOT NULL,
    "Start_Time" character varying(30) NOT NULL,
    "Location" character varying(30)
);
    DROP TABLE public."Exams";
       public         heap r       postgres    false    217    4         �            1259    17218    HasRoles    TABLE     m   CREATE TABLE public."HasRoles" (
    "UserID" integer NOT NULL,
    "Role" character varying(30) NOT NULL
);
    DROP TABLE public."HasRoles";
       public         heap r       postgres    false    4         �            1259    17328    requests_sq    SEQUENCE     z   CREATE SEQUENCE public.requests_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000000
    CACHE 1;
 "   DROP SEQUENCE public.requests_sq;
       public               postgres    false    4         �            1259    17331    Requests    TABLE     N  CREATE TABLE public."Requests" (
    "RequestID" integer DEFAULT nextval('public.requests_sq'::regclass) NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "Group" integer NOT NULL,
    "Date" date NOT NULL,
    "Status" character varying(30) NOT NULL,
    "RejectionReason" character varying(200)
);
    DROP TABLE public."Requests";
       public         heap r       postgres    false    225    4         �            1259    17224    StudentGroup    TABLE     d   CREATE TABLE public."StudentGroup" (
    "UserID" integer NOT NULL,
    "Group" integer NOT NULL
);
 "   DROP TABLE public."StudentGroup";
       public         heap r       postgres    false    4         �            1259    17227    subjects_sq    SEQUENCE     x   CREATE SEQUENCE public.subjects_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 1;
 "   DROP SEQUENCE public.subjects_sq;
       public               postgres    false    4         �            1259    17228    Subjects    TABLE     �   CREATE TABLE public."Subjects" (
    "SubjectID" integer DEFAULT nextval('public.subjects_sq'::regclass) NOT NULL,
    "ProfessorID" integer NOT NULL,
    "SubjectName" character varying(30) NOT NULL
);
    DROP TABLE public."Subjects";
       public         heap r       postgres    false    221    4         �            1259    17235    users_sq    SEQUENCE     u   CREATE SEQUENCE public.users_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 1;
    DROP SEQUENCE public.users_sq;
       public               postgres    false    4         �            1259    17236    Users    TABLE     &  CREATE TABLE public."Users" (
    "UserID" integer DEFAULT nextval('public.users_sq'::regclass) NOT NULL,
    "FirstName" character varying(30) NOT NULL,
    "LastName" character varying(30) NOT NULL,
    "Email" character varying(30) NOT NULL,
    "Password" character varying(30) NOT NULL
);
    DROP TABLE public."Users";
       public         heap r       postgres    false    223    4         �          0    17214    Exams 
   TABLE DATA           �   COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "Location") FROM stdin;
    public               postgres    false    218       4834.dat �          0    17218    HasRoles 
   TABLE DATA           6   COPY public."HasRoles" ("UserID", "Role") FROM stdin;
    public               postgres    false    219       4835.dat �          0    17331    Requests 
   TABLE DATA           {   COPY public."Requests" ("RequestID", "SubjectID", "ProfessorID", "Group", "Date", "Status", "RejectionReason") FROM stdin;
    public               postgres    false    226       4842.dat �          0    17224    StudentGroup 
   TABLE DATA           ;   COPY public."StudentGroup" ("UserID", "Group") FROM stdin;
    public               postgres    false    220       4836.dat �          0    17228    Subjects 
   TABLE DATA           O   COPY public."Subjects" ("SubjectID", "ProfessorID", "SubjectName") FROM stdin;
    public               postgres    false    222       4838.dat �          0    17236    Users 
   TABLE DATA           Y   COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM stdin;
    public               postgres    false    224       4840.dat �           0    0    exams_sq    SEQUENCE SET     6   SELECT pg_catalog.setval('public.exams_sq', 2, true);
          public               postgres    false    217         �           0    0    requests_sq    SEQUENCE SET     9   SELECT pg_catalog.setval('public.requests_sq', 4, true);
          public               postgres    false    225         �           0    0    subjects_sq    SEQUENCE SET     9   SELECT pg_catalog.setval('public.subjects_sq', 9, true);
          public               postgres    false    221         �           0    0    users_sq    SEQUENCE SET     7   SELECT pg_catalog.setval('public.users_sq', 31, true);
          public               postgres    false    223         =           2606    17243    Exams Exams_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "Exams_pkey" PRIMARY KEY ("ExamID");
 >   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "Exams_pkey";
       public                 postgres    false    218         ?           2606    17245    HasRoles HasRoles_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "HasRoles_pkey" PRIMARY KEY ("UserID", "Role");
 D   ALTER TABLE ONLY public."HasRoles" DROP CONSTRAINT "HasRoles_pkey";
       public                 postgres    false    219    219         A           2606    17249    StudentGroup StudentGroup_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT "StudentGroup_pkey" PRIMARY KEY ("UserID");
 L   ALTER TABLE ONLY public."StudentGroup" DROP CONSTRAINT "StudentGroup_pkey";
       public                 postgres    false    220         E           2606    17253    Users Users_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("UserID");
 >   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_pkey";
       public                 postgres    false    224         G           2606    17336    Requests pk_request 
   CONSTRAINT     \   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT pk_request PRIMARY KEY ("RequestID");
 ?   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT pk_request;
       public                 postgres    false    226         C           2606    17255    Subjects subjects_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT subjects_pkey PRIMARY KEY ("SubjectID");
 B   ALTER TABLE ONLY public."Subjects" DROP CONSTRAINT subjects_pkey;
       public                 postgres    false    222         H           2606    17256    Exams FK_exams_subjects    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_subjects" FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;
 E   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_subjects";
       public               postgres    false    222    218    4675         I           2606    17261    Exams FK_exams_users_1    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_1" FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;
 D   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_users_1";
       public               postgres    false    218    4677    224         J           2606    17266    Exams FK_exams_users_2    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_2" FOREIGN KEY ("AssistantID") REFERENCES public."Users"("UserID") MATCH FULL;
 D   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_users_2";
       public               postgres    false    224    218    4677         K           2606    17271    HasRoles FK_hasroles_users    FK CONSTRAINT     �   ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "FK_hasroles_users" FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;
 H   ALTER TABLE ONLY public."HasRoles" DROP CONSTRAINT "FK_hasroles_users";
       public               postgres    false    4677    219    224         L           2606    17286    StudentGroup fk_group_user    FK CONSTRAINT     �   ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT fk_group_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID");
 F   ALTER TABLE ONLY public."StudentGroup" DROP CONSTRAINT fk_group_user;
       public               postgres    false    4677    220    224         N           2606    17342    Requests fk_req_prof    FK CONSTRAINT     �   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_prof FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;
 @   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT fk_req_prof;
       public               postgres    false    4677    224    226         O           2606    17337    Requests fk_req_sub    FK CONSTRAINT     �   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_sub FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;
 ?   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT fk_req_sub;
       public               postgres    false    222    226    4675         M           2606    17315    Subjects fk_subjects_users    FK CONSTRAINT     �   ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT fk_subjects_users FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL NOT VALID;
 F   ALTER TABLE ONLY public."Subjects" DROP CONSTRAINT fk_subjects_users;
       public               postgres    false    222    224    4677                                                                                                                                                                                                      4834.dat                                                                                            0000600 0004000 0002000 00000000122 14720264421 0014251 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	3131	2	9	22	2024-11-23	12:00AM	c102
2	3132	4	10	22	2024-11-23	12:00AM	c102
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                              4835.dat                                                                                            0000600 0004000 0002000 00000000340 14720264421 0014254 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	Professor
3	Student
8	Professsor
9	Professsor
9	Professor
10	Professor
11	Professor
12	Professor
13	Professor
18	Student
19	Student
20	Student
21	Student
22	Student
10	Assistant
11	Assistant
12	Assistant
13	Assistant
\.


                                                                                                                                                                                                                                                                                                4842.dat                                                                                            0000600 0004000 0002000 00000000226 14720264421 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	2	8	3131	2024-11-23	Pending	\N
2	3	9	3132	2024-11-23	Pending	\N
3	4	10	3132	2024-11-23	Pending	\N
4	8	10	3133	2024-11-23	Rejected	Another Date
\.


                                                                                                                                                                                                                                                                                                                                                                          4836.dat                                                                                            0000600 0004000 0002000 00000000013 14720264421 0014252 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        3	101
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     4838.dat                                                                                            0000600 0004000 0002000 00000000063 14720264421 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	8	MD
3	9	IP
4	10	DEEA
8	13	DEEA2
9	14	DEEA3
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                             4840.dat                                                                                            0000600 0004000 0002000 00000002003 14720264421 0014246 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	John	Pork	john.pork@gmail.com	isCallingYou
3	Jack	Smith	smith9023@gmail.com	pass123
4	Rand	O	user@example.com	123
5	Rand	O	user@example.com	123
6	gg	ff	user@example.com	123
7	gg	ff	user@example.com	123
8	Prof	1	user@example.com	pas123
9	Prof	2	user@example.com	pas123
10	Prof	3	user@example.com	pas123
11	Prof	4	user@example.com	pas123
12	Prof	5	user@example.com	pas123
13	Prof	6	user@example.com	pas123
14	Prof	7	user@example.com	pas123
15	Prof	8	user@example.com	pas123
16	Prof	9	user@example.com	pas123
17	Prof	10	user@example.com	pas123
18	Stud	1	user@example.com	pas123
19	Stud	2	user@example.com	pas123
20	Stud	3	user@example.com	pas123
21	Stud	4	user@example.com	pas123
22	Stud	5	user@example.com	pas123
23	Stud	6	user@example.com	pas123
24	Stud	7	user@example.com	pas123
25	Stud	8	user@example.com	pas123
26	Stud	9	user@example.com	pas123
27	Stud	10	user@example.com	pas123
28	Assist	1	user@example.com	pas123
29	Assist	2	user@example.com	pas123
30	Assist	3	user@example.com	pas123
31	ef	sf	user@example.com	123
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             restore.sql                                                                                         0000600 0004000 0002000 00000023564 14720264421 0015400 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 17.1
-- Dumped by pg_dump version 17.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE examplanner;
--
-- Name: examplanner; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE examplanner WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';


ALTER DATABASE examplanner OWNER TO postgres;

\connect examplanner

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- Name: exams_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.exams_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000000
    CACHE 1;


ALTER SEQUENCE public.exams_sq OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Exams; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Exams" (
    "ExamID" integer DEFAULT nextval('public.exams_sq'::regclass) NOT NULL,
    "Group" integer NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "AssistantID" integer,
    "Date" date NOT NULL,
    "Start_Time" character varying(30) NOT NULL,
    "Location" character varying(30)
);


ALTER TABLE public."Exams" OWNER TO postgres;

--
-- Name: HasRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HasRoles" (
    "UserID" integer NOT NULL,
    "Role" character varying(30) NOT NULL
);


ALTER TABLE public."HasRoles" OWNER TO postgres;

--
-- Name: requests_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.requests_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000000
    CACHE 1;


ALTER SEQUENCE public.requests_sq OWNER TO postgres;

--
-- Name: Requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Requests" (
    "RequestID" integer DEFAULT nextval('public.requests_sq'::regclass) NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "Group" integer NOT NULL,
    "Date" date NOT NULL,
    "Status" character varying(30) NOT NULL,
    "RejectionReason" character varying(200)
);


ALTER TABLE public."Requests" OWNER TO postgres;

--
-- Name: StudentGroup; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StudentGroup" (
    "UserID" integer NOT NULL,
    "Group" integer NOT NULL
);


ALTER TABLE public."StudentGroup" OWNER TO postgres;

--
-- Name: subjects_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subjects_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 1;


ALTER SEQUENCE public.subjects_sq OWNER TO postgres;

--
-- Name: Subjects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Subjects" (
    "SubjectID" integer DEFAULT nextval('public.subjects_sq'::regclass) NOT NULL,
    "ProfessorID" integer NOT NULL,
    "SubjectName" character varying(30) NOT NULL
);


ALTER TABLE public."Subjects" OWNER TO postgres;

--
-- Name: users_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 1;


ALTER SEQUENCE public.users_sq OWNER TO postgres;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "UserID" integer DEFAULT nextval('public.users_sq'::regclass) NOT NULL,
    "FirstName" character varying(30) NOT NULL,
    "LastName" character varying(30) NOT NULL,
    "Email" character varying(30) NOT NULL,
    "Password" character varying(30) NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- Data for Name: Exams; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "Location") FROM stdin;
\.
COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "Location") FROM '$$PATH$$/4834.dat';

--
-- Data for Name: HasRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."HasRoles" ("UserID", "Role") FROM stdin;
\.
COPY public."HasRoles" ("UserID", "Role") FROM '$$PATH$$/4835.dat';

--
-- Data for Name: Requests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Requests" ("RequestID", "SubjectID", "ProfessorID", "Group", "Date", "Status", "RejectionReason") FROM stdin;
\.
COPY public."Requests" ("RequestID", "SubjectID", "ProfessorID", "Group", "Date", "Status", "RejectionReason") FROM '$$PATH$$/4842.dat';

--
-- Data for Name: StudentGroup; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StudentGroup" ("UserID", "Group") FROM stdin;
\.
COPY public."StudentGroup" ("UserID", "Group") FROM '$$PATH$$/4836.dat';

--
-- Data for Name: Subjects; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Subjects" ("SubjectID", "ProfessorID", "SubjectName") FROM stdin;
\.
COPY public."Subjects" ("SubjectID", "ProfessorID", "SubjectName") FROM '$$PATH$$/4838.dat';

--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM stdin;
\.
COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM '$$PATH$$/4840.dat';

--
-- Name: exams_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.exams_sq', 2, true);


--
-- Name: requests_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.requests_sq', 4, true);


--
-- Name: subjects_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subjects_sq', 9, true);


--
-- Name: users_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_sq', 31, true);


--
-- Name: Exams Exams_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "Exams_pkey" PRIMARY KEY ("ExamID");


--
-- Name: HasRoles HasRoles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "HasRoles_pkey" PRIMARY KEY ("UserID", "Role");


--
-- Name: StudentGroup StudentGroup_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT "StudentGroup_pkey" PRIMARY KEY ("UserID");


--
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("UserID");


--
-- Name: Requests pk_request; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT pk_request PRIMARY KEY ("RequestID");


--
-- Name: Subjects subjects_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT subjects_pkey PRIMARY KEY ("SubjectID");


--
-- Name: Exams FK_exams_subjects; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_subjects" FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;


--
-- Name: Exams FK_exams_users_1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_1" FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: Exams FK_exams_users_2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_2" FOREIGN KEY ("AssistantID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: HasRoles FK_hasroles_users; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "FK_hasroles_users" FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: StudentGroup fk_group_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT fk_group_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID");


--
-- Name: Requests fk_req_prof; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_prof FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: Requests fk_req_sub; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_sub FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;


--
-- Name: Subjects fk_subjects_users; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT fk_subjects_users FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL NOT VALID;


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            