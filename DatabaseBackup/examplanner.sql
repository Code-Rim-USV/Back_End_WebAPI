toc.dat                                                                                             0000600 0004000 0002000 00000032501 14717111644 0014446 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP       !            
    |            examplanner    17.0    17.0 -    1           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false         2           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false         3           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false         4           1262    25644    examplanner    DATABASE     �   CREATE DATABASE examplanner WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.utf8';
    DROP DATABASE examplanner;
                     postgres    false         �            1259    25645    Attends    TABLE     `   CREATE TABLE public."Attends" (
    "UserID" integer NOT NULL,
    "ExamID" integer NOT NULL
);
    DROP TABLE public."Attends";
       public         heap r       postgres    false         �            1259    25648    exams_sq    SEQUENCE     w   CREATE SEQUENCE public.exams_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000000
    CACHE 50;
    DROP SEQUENCE public.exams_sq;
       public               postgres    false         �            1259    25649    Exams    TABLE     r  CREATE TABLE public."Exams" (
    "ExamID" integer DEFAULT nextval('public.exams_sq'::regclass) NOT NULL,
    "Group" integer NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "AssistantID" integer,
    "Date" date NOT NULL,
    "Start_Time" integer,
    "Location" character varying(30),
    "Status" character varying(30) NOT NULL
);
    DROP TABLE public."Exams";
       public         heap r       postgres    false    218         �            1259    25653    HasRoles    TABLE     m   CREATE TABLE public."HasRoles" (
    "UserID" integer NOT NULL,
    "Role" character varying(30) NOT NULL
);
    DROP TABLE public."HasRoles";
       public         heap r       postgres    false         �            1259    25656    Requests    TABLE     a   CREATE TABLE public."Requests" (
    "UserID" integer NOT NULL,
    "ExamID" integer NOT NULL
);
    DROP TABLE public."Requests";
       public         heap r       postgres    false         �            1259    25659    StudentGroup    TABLE     d   CREATE TABLE public."StudentGroup" (
    "UserID" integer NOT NULL,
    "Group" integer NOT NULL
);
 "   DROP TABLE public."StudentGroup";
       public         heap r       postgres    false         �            1259    25662    subjects_sq    SEQUENCE     y   CREATE SEQUENCE public.subjects_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 50;
 "   DROP SEQUENCE public.subjects_sq;
       public               postgres    false         �            1259    25663    Subjects    TABLE     �   CREATE TABLE public."Subjects" (
    "SubjectID" integer DEFAULT nextval('public.subjects_sq'::regclass) NOT NULL,
    "SubjectName" character varying(30) NOT NULL
);
    DROP TABLE public."Subjects";
       public         heap r       postgres    false    223         �            1259    25667    Teaches    TABLE     �   CREATE TABLE public."Teaches" (
    "UserID" integer NOT NULL,
    "SubjectID" integer NOT NULL,
    "Role" character varying(30) NOT NULL
);
    DROP TABLE public."Teaches";
       public         heap r       postgres    false         �            1259    25670    users_sq    SEQUENCE     v   CREATE SEQUENCE public.users_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 50;
    DROP SEQUENCE public.users_sq;
       public               postgres    false         �            1259    25671    Users    TABLE     &  CREATE TABLE public."Users" (
    "UserID" integer DEFAULT nextval('public.users_sq'::regclass) NOT NULL,
    "FirstName" character varying(30) NOT NULL,
    "LastName" character varying(30) NOT NULL,
    "Email" character varying(30) NOT NULL,
    "Password" character varying(30) NOT NULL
);
    DROP TABLE public."Users";
       public         heap r       postgres    false    226         $          0    25645    Attends 
   TABLE DATA           7   COPY public."Attends" ("UserID", "ExamID") FROM stdin;
    public               postgres    false    217       4900.dat &          0    25649    Exams 
   TABLE DATA           �   COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "Location", "Status") FROM stdin;
    public               postgres    false    219       4902.dat '          0    25653    HasRoles 
   TABLE DATA           6   COPY public."HasRoles" ("UserID", "Role") FROM stdin;
    public               postgres    false    220       4903.dat (          0    25656    Requests 
   TABLE DATA           8   COPY public."Requests" ("UserID", "ExamID") FROM stdin;
    public               postgres    false    221       4904.dat )          0    25659    StudentGroup 
   TABLE DATA           ;   COPY public."StudentGroup" ("UserID", "Group") FROM stdin;
    public               postgres    false    222       4905.dat +          0    25663    Subjects 
   TABLE DATA           @   COPY public."Subjects" ("SubjectID", "SubjectName") FROM stdin;
    public               postgres    false    224       4907.dat ,          0    25667    Teaches 
   TABLE DATA           B   COPY public."Teaches" ("UserID", "SubjectID", "Role") FROM stdin;
    public               postgres    false    225       4908.dat .          0    25671    Users 
   TABLE DATA           Y   COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM stdin;
    public               postgres    false    227       4910.dat 5           0    0    exams_sq    SEQUENCE SET     7   SELECT pg_catalog.setval('public.exams_sq', 1, false);
          public               postgres    false    218         6           0    0    subjects_sq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.subjects_sq', 50, true);
          public               postgres    false    223         7           0    0    users_sq    SEQUENCE SET     7   SELECT pg_catalog.setval('public.users_sq', 50, true);
          public               postgres    false    226         y           2606    25676    Attends Attends_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."Attends"
    ADD CONSTRAINT "Attends_pkey" PRIMARY KEY ("UserID", "ExamID");
 B   ALTER TABLE ONLY public."Attends" DROP CONSTRAINT "Attends_pkey";
       public                 postgres    false    217    217         {           2606    25678    Exams Exams_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "Exams_pkey" PRIMARY KEY ("ExamID");
 >   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "Exams_pkey";
       public                 postgres    false    219         }           2606    25680    HasRoles HasRoles_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "HasRoles_pkey" PRIMARY KEY ("UserID", "Role");
 D   ALTER TABLE ONLY public."HasRoles" DROP CONSTRAINT "HasRoles_pkey";
       public                 postgres    false    220    220                    2606    25682    Requests Requests_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT "Requests_pkey" PRIMARY KEY ("UserID", "ExamID");
 D   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT "Requests_pkey";
       public                 postgres    false    221    221         �           2606    25684    StudentGroup StudentGroup_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT "StudentGroup_pkey" PRIMARY KEY ("UserID");
 L   ALTER TABLE ONLY public."StudentGroup" DROP CONSTRAINT "StudentGroup_pkey";
       public                 postgres    false    222         �           2606    25686    Teaches Teaches_pkey 
   CONSTRAINT     i   ALTER TABLE ONLY public."Teaches"
    ADD CONSTRAINT "Teaches_pkey" PRIMARY KEY ("UserID", "SubjectID");
 B   ALTER TABLE ONLY public."Teaches" DROP CONSTRAINT "Teaches_pkey";
       public                 postgres    false    225    225         �           2606    25688    Users Users_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("UserID");
 >   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_pkey";
       public                 postgres    false    227         �           2606    25690    Subjects subjects_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT subjects_pkey PRIMARY KEY ("SubjectID");
 B   ALTER TABLE ONLY public."Subjects" DROP CONSTRAINT subjects_pkey;
       public                 postgres    false    224         �           2606    25691    Exams FK_exams_subjects    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_subjects" FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;
 E   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_subjects";
       public               postgres    false    4739    219    224         �           2606    25696    Exams FK_exams_users_1    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_1" FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;
 D   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_users_1";
       public               postgres    false    4743    219    227         �           2606    25701    Exams FK_exams_users_2    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_2" FOREIGN KEY ("AssistantID") REFERENCES public."Users"("UserID") MATCH FULL;
 D   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_users_2";
       public               postgres    false    4743    219    227         �           2606    25706    HasRoles FK_hasroles_users    FK CONSTRAINT     �   ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "FK_hasroles_users" FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;
 H   ALTER TABLE ONLY public."HasRoles" DROP CONSTRAINT "FK_hasroles_users";
       public               postgres    false    4743    220    227         �           2606    25711    Attends fk_att_exam    FK CONSTRAINT     �   ALTER TABLE ONLY public."Attends"
    ADD CONSTRAINT fk_att_exam FOREIGN KEY ("ExamID") REFERENCES public."Exams"("ExamID") MATCH FULL;
 ?   ALTER TABLE ONLY public."Attends" DROP CONSTRAINT fk_att_exam;
       public               postgres    false    4731    217    219         �           2606    25716    Attends fk_att_user    FK CONSTRAINT     �   ALTER TABLE ONLY public."Attends"
    ADD CONSTRAINT fk_att_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;
 ?   ALTER TABLE ONLY public."Attends" DROP CONSTRAINT fk_att_user;
       public               postgres    false    217    227    4743         �           2606    25721    StudentGroup fk_group_user    FK CONSTRAINT     �   ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT fk_group_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID");
 F   ALTER TABLE ONLY public."StudentGroup" DROP CONSTRAINT fk_group_user;
       public               postgres    false    4743    227    222         �           2606    25726    Requests fk_req_exam    FK CONSTRAINT     �   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_exam FOREIGN KEY ("ExamID") REFERENCES public."Exams"("ExamID") MATCH FULL;
 @   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT fk_req_exam;
       public               postgres    false    219    4731    221         �           2606    25731    Requests fk_req_user    FK CONSTRAINT     �   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;
 @   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT fk_req_user;
       public               postgres    false    221    227    4743         �           2606    25736    Teaches fk_teach_subject    FK CONSTRAINT     �   ALTER TABLE ONLY public."Teaches"
    ADD CONSTRAINT fk_teach_subject FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;
 D   ALTER TABLE ONLY public."Teaches" DROP CONSTRAINT fk_teach_subject;
       public               postgres    false    225    224    4739         �           2606    25741    Teaches fk_teach_user    FK CONSTRAINT     �   ALTER TABLE ONLY public."Teaches"
    ADD CONSTRAINT fk_teach_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;
 A   ALTER TABLE ONLY public."Teaches" DROP CONSTRAINT fk_teach_user;
       public               postgres    false    227    225    4743                                                                                                                                                                                                       4900.dat                                                                                            0000600 0004000 0002000 00000000005 14717111644 0014247 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4902.dat                                                                                            0000600 0004000 0002000 00000000005 14717111644 0014251 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4903.dat                                                                                            0000600 0004000 0002000 00000000033 14717111644 0014253 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Professor
2	Student
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     4904.dat                                                                                            0000600 0004000 0002000 00000000005 14717111644 0014253 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4905.dat                                                                                            0000600 0004000 0002000 00000000013 14717111644 0014253 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	101
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     4907.dat                                                                                            0000600 0004000 0002000 00000000020 14717111644 0014253 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	GAC
2	MD
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                4908.dat                                                                                            0000600 0004000 0002000 00000000005 14717111644 0014257 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4910.dat                                                                                            0000600 0004000 0002000 00000000133 14717111644 0014252 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	John	Pork	john.pork@gmail.com	isCallingYou
2	Jack	Smith	smith9023@gmail.com	pass123
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                     restore.sql                                                                                         0000600 0004000 0002000 00000025420 14717111644 0015375 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0
-- Dumped by pg_dump version 17.0

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

CREATE DATABASE examplanner WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.utf8';


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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Attends; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Attends" (
    "UserID" integer NOT NULL,
    "ExamID" integer NOT NULL
);


ALTER TABLE public."Attends" OWNER TO postgres;

--
-- Name: exams_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.exams_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000000
    CACHE 50;


ALTER SEQUENCE public.exams_sq OWNER TO postgres;

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
    "Start_Time" integer,
    "Location" character varying(30),
    "Status" character varying(30) NOT NULL
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
-- Name: Requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Requests" (
    "UserID" integer NOT NULL,
    "ExamID" integer NOT NULL
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
    CACHE 50;


ALTER SEQUENCE public.subjects_sq OWNER TO postgres;

--
-- Name: Subjects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Subjects" (
    "SubjectID" integer DEFAULT nextval('public.subjects_sq'::regclass) NOT NULL,
    "SubjectName" character varying(30) NOT NULL
);


ALTER TABLE public."Subjects" OWNER TO postgres;

--
-- Name: Teaches; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Teaches" (
    "UserID" integer NOT NULL,
    "SubjectID" integer NOT NULL,
    "Role" character varying(30) NOT NULL
);


ALTER TABLE public."Teaches" OWNER TO postgres;

--
-- Name: users_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 50;


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
-- Data for Name: Attends; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Attends" ("UserID", "ExamID") FROM stdin;
\.
COPY public."Attends" ("UserID", "ExamID") FROM '$$PATH$$/4900.dat';

--
-- Data for Name: Exams; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "Location", "Status") FROM stdin;
\.
COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "Location", "Status") FROM '$$PATH$$/4902.dat';

--
-- Data for Name: HasRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."HasRoles" ("UserID", "Role") FROM stdin;
\.
COPY public."HasRoles" ("UserID", "Role") FROM '$$PATH$$/4903.dat';

--
-- Data for Name: Requests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Requests" ("UserID", "ExamID") FROM stdin;
\.
COPY public."Requests" ("UserID", "ExamID") FROM '$$PATH$$/4904.dat';

--
-- Data for Name: StudentGroup; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StudentGroup" ("UserID", "Group") FROM stdin;
\.
COPY public."StudentGroup" ("UserID", "Group") FROM '$$PATH$$/4905.dat';

--
-- Data for Name: Subjects; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Subjects" ("SubjectID", "SubjectName") FROM stdin;
\.
COPY public."Subjects" ("SubjectID", "SubjectName") FROM '$$PATH$$/4907.dat';

--
-- Data for Name: Teaches; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Teaches" ("UserID", "SubjectID", "Role") FROM stdin;
\.
COPY public."Teaches" ("UserID", "SubjectID", "Role") FROM '$$PATH$$/4908.dat';

--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM stdin;
\.
COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM '$$PATH$$/4910.dat';

--
-- Name: exams_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.exams_sq', 1, false);


--
-- Name: subjects_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subjects_sq', 50, true);


--
-- Name: users_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_sq', 50, true);


--
-- Name: Attends Attends_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Attends"
    ADD CONSTRAINT "Attends_pkey" PRIMARY KEY ("UserID", "ExamID");


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
-- Name: Requests Requests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT "Requests_pkey" PRIMARY KEY ("UserID", "ExamID");


--
-- Name: StudentGroup StudentGroup_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT "StudentGroup_pkey" PRIMARY KEY ("UserID");


--
-- Name: Teaches Teaches_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Teaches"
    ADD CONSTRAINT "Teaches_pkey" PRIMARY KEY ("UserID", "SubjectID");


--
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("UserID");


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
-- Name: Attends fk_att_exam; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Attends"
    ADD CONSTRAINT fk_att_exam FOREIGN KEY ("ExamID") REFERENCES public."Exams"("ExamID") MATCH FULL;


--
-- Name: Attends fk_att_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Attends"
    ADD CONSTRAINT fk_att_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: StudentGroup fk_group_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT fk_group_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID");


--
-- Name: Requests fk_req_exam; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_exam FOREIGN KEY ("ExamID") REFERENCES public."Exams"("ExamID") MATCH FULL;


--
-- Name: Requests fk_req_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: Teaches fk_teach_subject; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Teaches"
    ADD CONSTRAINT fk_teach_subject FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;


--
-- Name: Teaches fk_teach_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Teaches"
    ADD CONSTRAINT fk_teach_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                